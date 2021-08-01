using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]int deathEnergyBonus = 5;

    public override void Die()
    {
        PlayerEnergy.Instance.ObtainEnergy(deathEnergyBonus);
        EnemyManager.Instance.RemoveFromAliveList(gameObject);
        base.Die();
    }
}
