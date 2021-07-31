using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float speedUpTime = 0.2f;
    [SerializeField] float speedSlowTime = 0.15f;

    [SerializeField] float offsetX = 1f;
    [SerializeField] float offsetY = 0.4f;
    [SerializeField] float moveRotationAngle = 30f;

    [SerializeField] GameObject projectile_mid;
    [SerializeField] GameObject projectile_up;
    [SerializeField] GameObject projectile_down;
    [SerializeField, Range(1, 3)] int weaponPower = 1;
    [SerializeField] Transform muzzleMid;
    [SerializeField] Transform muzzleUp;
    [SerializeField] Transform muzzleDown;
    [SerializeField] float fireCd = 0.2f;
    WaitForSeconds waitForFireCd;

    Rigidbody2D rbody;
    Coroutine moveCoroutine;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.onMove += Move;
        playerInput.onStopMove += StopMove;
        playerInput.onFire += Fire;
        playerInput.onStopFire += StopFire;
    }

    void Start()
    {
        rbody.gravityScale = 0f;
        waitForFireCd = new WaitForSeconds(fireCd);
        playerInput.EnablePlayerControlMap();
    }

    private void OnDisable()
    {
        playerInput.onMove -= Move;
        playerInput.onStopMove -= StopMove;
        playerInput.onFire -= Fire;
        playerInput.onStopFire -= StopFire;
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
            t += Time.fixedDeltaTime / calcuTime;
            rbody.velocity = Vector2.Lerp(rbody.velocity, objVelocity, t / calcuTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, moveRotation, t / calcuTime);
            yield return null;
        }
    }


    #endregion

    #region fire
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
    #endregion
}
