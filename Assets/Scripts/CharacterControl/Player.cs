using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Character
{
    [Header("--- HP ---")]
    [SerializeField] bool isRecoverHP = true;
    [SerializeField] float hpRecoverTime;
    [SerializeField, Range(0f, 1f)] float hpRecoverPercent;
    [SerializeField] StatsBar_HUD statsBar_HUD;
    WaitForSeconds waitHpRecoverCd;

    [Header("--- Move ---")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedUpTime = 0.2f;
    [SerializeField] float speedSlowTime = 0.15f;
    [SerializeField] float offsetX = 1f;
    [SerializeField] float offsetY = 0.4f;
    [SerializeField] float moveRotationAngle = 30f;

    [Header("--- Battle ---")]
    [SerializeField] GameObject projectile_mid;
    [SerializeField] GameObject projectile_up;
    [SerializeField] GameObject projectile_down;
    [SerializeField, Range(1, 3)] int weaponPower = 1;
    [SerializeField] Transform muzzleMid;
    [SerializeField] Transform muzzleUp;
    [SerializeField] Transform muzzleDown;
    [SerializeField] float fireCd = 0.2f;
    [SerializeField, Range(0, 100)] int dodgeEnergyCost = 25;
    [SerializeField] float maxRoll = 720;
    [SerializeField] float rollSpeed = 360f;
    float curRoll;
    float dodgeDuration;
    Vector3 dodgeScale = new Vector3(0.65f, 0.65f, 0.65f);
    bool isDodgeing = false;
    Collider2D playerCollider;
    WaitForSeconds waitForFireCd;

    [SerializeField] PlayerInput playerInput;
    Rigidbody2D rbody;
    Coroutine moveCoroutine; // 禁用带参协程需要用变量先保存
    Coroutine hpRecoverCoroutine;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerInput.onMove += Move;
        playerInput.onStopMove += StopMove;
        playerInput.onFire += Fire;
        playerInput.onStopFire += StopFire;
        playerInput.onDodge += Dodge;
    }

    void Start()
    {
        rbody.gravityScale = 0f;
        dodgeDuration = maxRoll / rollSpeed;
        waitForFireCd = new WaitForSeconds(fireCd);
        waitHpRecoverCd = new WaitForSeconds(hpRecoverTime);
        playerInput.EnablePlayerControlMap();
        statsBar_HUD.Init(curHealth, maxHealth);
    }

    private void OnDisable()
    {
        playerInput.onMove -= Move;
        playerInput.onStopMove -= StopMove;
        playerInput.onFire -= Fire;
        playerInput.onStopFire -= StopFire;
        playerInput.onDodge -= Dodge;
    }


    #region move
    private void Move(Vector2 moveInput)
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);

        Quaternion moveRotation = Quaternion.AngleAxis(moveRotationAngle * moveInput.y, Vector3.right);
        moveCoroutine = StartCoroutine(MoveCalcuCoroutine(moveInput.normalized * moveSpeed, moveRotation,speedUpTime));
        StartCoroutine(MoveLimitCoroutine());
    }

    private void StopMove()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveCalcuCoroutine(Vector2.zero, Quaternion.identity, speedSlowTime));
        StopCoroutine(MoveLimitCoroutine());
    }

    IEnumerator MoveLimitCoroutine()
    {
        while (true)
        {
            transform.position = ViewPort.Instance.PlayerMoveablePosition(transform.position, offsetX, offsetY);
            yield return null;
        }
    }

    IEnumerator MoveCalcuCoroutine(Vector2 objVelocity, Quaternion moveRotation, float calcuTime)
    {
        float t = 0f;
        while (t < calcuTime)
        {
            t += Time.fixedDeltaTime;
            rbody.velocity = Vector2.Lerp(rbody.velocity, objVelocity, t / calcuTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, moveRotation, t / calcuTime);
            yield return null;
        }
    }


    #endregion

    #region Battle
    private void Fire()
    {
        StartCoroutine(nameof(FireCoroutine));
    }

    private void StopFire()
    {
        StopCoroutine(nameof(FireCoroutine));
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            //switch (weaponPower)
            //{
            //    case 1:
            //        Instantiate(projectile_mid, muzzleMid.position, Quaternion.identity);
            //        break;

            //    case 2:
            //        Instantiate(projectile_mid, muzzleUp.position, Quaternion.identity);
            //        Instantiate(projectile_mid, muzzleDown.position, Quaternion.identity);
            //        break;

            //    case 3:
            //        Instantiate(projectile_mid, muzzleMid.position, Quaternion.identity);
            //        Instantiate(projectile_up, muzzleUp.position, Quaternion.identity);
            //        Instantiate(projectile_down, muzzleDown.position, Quaternion.identity);
            //        break;
            //    default:
            //        break;
            //}

            switch (weaponPower) // 对象池模式管理子弹
            {
                case 1:
                    PoolManager.Release(projectile_mid, muzzleMid.position, Quaternion.identity);
                    break;

                case 2:
                    PoolManager.Release(projectile_mid, muzzleUp.position, Quaternion.identity);
                    PoolManager.Release(projectile_mid, muzzleDown.position, Quaternion.identity);
                    break;

                case 3:
                    PoolManager.Release(projectile_mid, muzzleMid.position, Quaternion.identity);
                    PoolManager.Release(projectile_up, muzzleUp.position, Quaternion.identity);
                    PoolManager.Release(projectile_down, muzzleDown.position, Quaternion.identity);
                    break;
                default:
                    break;
            }

            yield return waitForFireCd;
        }
    }

    void Dodge()
    {
        if (isDodgeing || !PlayerEnergy.Instance.IsEnough(dodgeEnergyCost)) return;
        StartCoroutine(nameof(DodgeCoroutine));
    }

    IEnumerator DodgeCoroutine()
    {
        isDodgeing = true;
        PlayerEnergy.Instance.UseEnergy(dodgeEnergyCost); //消耗能量

        playerCollider.isTrigger = true; // 变为无敌
        curRoll = 0f;
        var scale = transform.localScale;
        var t1 = 0f;
        var t2 = 0f;
        while (curRoll < maxRoll)
        {
            curRoll += rollSpeed * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(curRoll, Vector3.right);

            if(curRoll < maxRoll / 2) // 三维插值实现缩放
            {
                t1 += Time.deltaTime / dodgeDuration;
                transform.localScale = Vector3.Lerp(transform.localScale, dodgeScale, t1);
            }
            else
            {
                t2 += Time.deltaTime / dodgeDuration;
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, t2);
            }

            //if(curRoll < maxRoll / 2) // 直接计算实现缩放
            //{
            //    scale.x = Mathf.Clamp(scale.x - Time.deltaTime / dodgeDuration, dodgeScale.x, 1f);
            //    scale.y = Mathf.Clamp(scale.y - Time.deltaTime / dodgeDuration, dodgeScale.y, 1f);
            //    scale.z = Mathf.Clamp(scale.z - Time.deltaTime / dodgeDuration, dodgeScale.z, 1f);
            //}
            //else
            //{
            //    scale.x = Mathf.Clamp(scale.x + Time.deltaTime / dodgeDuration, dodgeScale.x, 1f);
            //    scale.y = Mathf.Clamp(scale.y + Time.deltaTime / dodgeDuration, dodgeScale.y, 1f);
            //    scale.z = Mathf.Clamp(scale.z + Time.deltaTime / dodgeDuration, dodgeScale.z, 1f);
            //}
            //transform.localScale = scale;
            yield return null;
        }

        isDodgeing = false;
        playerCollider.isTrigger = false;
    }
    #endregion

    #region HP
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        statsBar_HUD.UpdateState(curHealth, maxHealth);

        if (gameObject.activeSelf)
        {
            if (isRecoverHP)
            {
                if (hpRecoverCoroutine != null)
                {
                    StopCoroutine(hpRecoverCoroutine);
                }
                hpRecoverCoroutine = StartCoroutine(HealthRecoverCoroutine(waitHpRecoverCd, hpRecoverPercent));
            }
        }
    }

    public override void RecoverHealth(float value)
    {
        base.RecoverHealth(value);
        statsBar_HUD.UpdateState(curHealth, maxHealth);
    }

    public override void Die()
    {
        statsBar_HUD.UpdateState(0f, maxHealth);
        base.Die();
    }
    #endregion


}
