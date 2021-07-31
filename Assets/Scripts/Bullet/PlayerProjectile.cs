using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        if (moveDirection != Vector2.right) // 玩家子弹强制向右
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.right, moveDirection);
        }
    }

    private void OnDisable()
    {
        trail.Clear(); // 修复对象池模式中子弹轨迹异常问题
    }

}
