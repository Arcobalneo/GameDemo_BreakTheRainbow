using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        if (moveDirection != Vector2.right) // ����ӵ�ǿ������
        {
            transform.GetChild(0).rotation = Quaternion.FromToRotation(Vector2.right, moveDirection);
        }
    }

    private void OnDisable()
    {
        trail.Clear(); // �޸������ģʽ���ӵ��켣�쳣����
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        PlayerEnergy.Instance.ObtainEnergy(PlayerEnergy.MAX_PERCENT);
    }
}
