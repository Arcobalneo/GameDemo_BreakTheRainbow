using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPort : Singleton<ViewPort>
{
    float minX, minY, maxX, maxY, midX;

    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f));
        minX = bottomLeft.x;
        minY = bottomLeft.y;

        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f));
        maxX = topRight.x;
        maxY = topRight.y;

        midX = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f)).x;
    }

    public Vector3 PlayerMoveablePosition(Vector3 playerPosition, float offsetX,float offsetY)
    {
        Vector3 position = Vector3.zero;
        position.x = Mathf.Clamp(playerPosition.x, minX + offsetX, maxX - offsetX);
        position.y = Mathf.Clamp(playerPosition.y, minY + offsetY, maxY - offsetY);
        return position;
    }

    public Vector3 RandomEnemyBornPos(float offsetX,float offsetY)
    {
        Vector3 pos = Vector3.zero;

        pos.x = maxX + offsetX; // 敌人在屏幕外刷新
        pos.y = Random.Range(minY + offsetY, maxY - offsetY);

        return pos;
    }

    public Vector3 RandomRightHalfPos(float offsetX, float offsetY) // 限制敌人在屏幕右半移动
    {
        Vector3 pos = Vector3.zero;

        pos.x = Random.Range(midX, maxX - offsetX);
        pos.y = Random.Range(minY + offsetY, maxY - offsetY);

        return pos;
    }
}
