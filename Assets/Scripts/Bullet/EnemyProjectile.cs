using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void Awake()
    {
        if(moveDirection != Vector2.left) // 敌人子弹强制向左
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.left, moveDirection);
        }
    }
}
