using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("--- Move ---")]
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float moveRotationAngle = 25f;

    [Header("--- Fire ---")]
    [SerializeField] float minFireCd;
    [SerializeField] float maxFireCd;
    [SerializeField] GameObject[] projectiles;
    [SerializeField] Transform muzzle;
    private void OnEnable()
    {
        StartCoroutine(nameof(RandomMoveCoroutine));
        StartCoroutine(nameof(RandomFireCoroutine));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator RandomMoveCoroutine()
    {
        transform.position = ViewPort.Instance.RandomEnemyBornPos(offsetX,offsetY);
        Vector3 targetPos = ViewPort.Instance.RandomRightHalfPos(offsetX, offsetY);

        while (gameObject.activeSelf)
        {
            if(Vector3.Distance(transform.position, targetPos) > Mathf.Epsilon) // 尚未到达随机目标点
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                
                transform.rotation = Quaternion.AngleAxis((targetPos-transform.position).normalized.y * moveRotationAngle, Vector3.right);
            }
            else // 更新下一随机目标点
            {
                targetPos = ViewPort.Instance.RandomRightHalfPos(offsetX, offsetY);
            }
            yield return null;
        }
    }

    IEnumerator RandomFireCoroutine()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(Random.Range(minFireCd, maxFireCd));
            foreach(var proj in projectiles)
            {
                PoolManager.Release(proj, muzzle.position); // 对象池管理敌人子弹
            }
        }
    }
}
