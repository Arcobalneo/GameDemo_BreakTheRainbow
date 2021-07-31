using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;

    [Header("--- HP ---")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float health;

    protected virtual void OnEnable()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        health = 0f;
        PoolManager.Release(deathVFX, transform.position);
        gameObject.SetActive(false);
    }

    public virtual void RecoverHealth(float value)
    {
        if (health == maxHealth) return;
        health = Mathf.Clamp(health + value, 0f, maxHealth);
    }

    protected IEnumerator HealthRecoverCoroutine(WaitForSeconds waitTime, float percent)
    {
        while(health < maxHealth)
        {
            yield return waitTime;
            RecoverHealth(maxHealth * percent);
        }
    }

    protected IEnumerator DamageOverTimeCoroutine(WaitForSeconds waitTime, float percent)
    {
        while (health > 0f)
        {
            yield return waitTime;
            TakeDamage(maxHealth * percent);
        }
    }
}
