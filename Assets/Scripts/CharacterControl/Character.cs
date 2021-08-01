using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;

    [Header("--- HP ---")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float curHealth;
    [SerializeField] StatsBar healthBarOnHead;
    [SerializeField] bool isShowHealthBarOnHead = true;

    protected virtual void OnEnable()
    {
        curHealth = maxHealth;

        if (isShowHealthBarOnHead)
        {
            ShowHealthBarOnHead();
        }
        else
        {
            HideHealthBarOnHead();
        }
    }

    #region UI
    public void ShowHealthBarOnHead()
    {
        healthBarOnHead.gameObject.SetActive(true);
        healthBarOnHead.Init(curHealth, maxHealth);
    }

    public void HideHealthBarOnHead()
    {
        healthBarOnHead.gameObject.SetActive(false);
    }
    #endregion

    public virtual void TakeDamage(float damage)
    {
        curHealth -= damage;


        if (isShowHealthBarOnHead && gameObject.activeSelf) // 受到伤害更新UI
        {
            healthBarOnHead.UpdateState(curHealth, maxHealth);
        }

        if(curHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        curHealth = 0f;
        PoolManager.Release(deathVFX, transform.position);
        gameObject.SetActive(false);
    }

    public virtual void RecoverHealth(float value)
    {
        if (curHealth == maxHealth) return;
        curHealth = Mathf.Clamp(curHealth + value, 0f, maxHealth);

        if (isShowHealthBarOnHead) // 恢复血量更新UI
        {
            healthBarOnHead.UpdateState(curHealth, maxHealth);
        }
    }

    protected IEnumerator HealthRecoverCoroutine(WaitForSeconds waitTime, float percent)
    {
        while(curHealth < maxHealth)
        {
            yield return waitTime;
            RecoverHealth(maxHealth * percent);
        }
    }

    protected IEnumerator DamageOverTimeCoroutine(WaitForSeconds waitTime, float percent)
    {
        while (curHealth > 0f)
        {
            yield return waitTime;
            TakeDamage(maxHealth * percent);
        }
    }
}
