using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilePools;

    [SerializeField] Pool[] enemyProjectilePools;

    [SerializeField] Pool[] VFXPools;

    [SerializeField] Pool[] enemyPools;
    static Dictionary<GameObject, Pool> poolDict;

    private void Awake()
    {
        poolDict = new Dictionary<GameObject, Pool>();
        Init(playerProjectilePools);
        Init(enemyProjectilePools);
        Init(VFXPools);
        Init(enemyPools);
    }

    void Init(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            if (poolDict.ContainsKey(pool.Prefab))
            {
                Debug.LogWarning("Same prefab( " + pool.Prefab.name + " ) in multiple pools");
                continue;
            }

            poolDict.Add(pool.Prefab,pool);
            Transform poolParent = new GameObject("Pool_" + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Init(poolParent);
        }
    }
#if UNITY_EDITOR
    void CheckSize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            if(pool.RuntimeSize > pool.Size)
            {
                Debug.LogWarning(string.Format(
                    "pool {0} has bigger runtime size {1} than init size {2}",
                    pool.Prefab.name,
                    pool.RuntimeSize,
                    pool.Size
                    )) ;
            }
        }
    }

    private void OnDestroy()
    {
        CheckSize(enemyPools);
        CheckSize(playerProjectilePools);
        CheckSize(enemyProjectilePools);
        CheckSize(VFXPools);
    }
#endif

    /// <summary>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数返回对象池中预备对象</para>
    /// </summary>
    public static GameObject Release(GameObject prefab)
    {
        if (!poolDict.ContainsKey(prefab))
        {
            Debug.LogError("Pool manager cannot find prefab: " + prefab.name);
            return null;
        }
        return poolDict[prefab].GetPreparedObj();
    }

    public static GameObject Release(GameObject prefab,Vector3 pos)
    {
        if (!poolDict.ContainsKey(prefab))
        {
            Debug.LogError("Pool manager cannot find prefab: " + prefab.name);
            return null;
        }
        return poolDict[prefab].GetPreparedObj(pos);
    }

    public static GameObject Release(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (!poolDict.ContainsKey(prefab))
        {
            Debug.LogError("Pool manager cannot find prefab: " + prefab.name);
            return null;
        }
        return poolDict[prefab].GetPreparedObj(pos, rot);
    }

    public static GameObject Release(GameObject prefab, Vector3 pos, Quaternion rot, Vector3 scale)
    {
        if (!poolDict.ContainsKey(prefab))
        {
            Debug.LogError("Pool manager cannot find prefab: " + prefab.name);
            return null;
        }
        return poolDict[prefab].GetPreparedObj(pos, rot, scale);
    }
}
