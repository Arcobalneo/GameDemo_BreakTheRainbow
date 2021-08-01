using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] bool spawnEnemy = true;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float timeBetweenWaves = 2f;

    int waveNumber = 1;
    int enemyAmount;
    int minEnemyAmount = 3;
    int maxEnemyAmount = 10;

    List<GameObject> aliveEnemyList;

    WaitForSeconds waitTimeBetweenSpawns;
    WaitForSeconds waitTimeBetweenWaves;
    WaitUntil waitUntilNoEnemy;

    protected override void Awake()
    {
        base.Awake();
        aliveEnemyList = new List<GameObject>();
        waitTimeBetweenSpawns = new WaitForSeconds(timeBetweenSpawns);
        waitTimeBetweenWaves = new WaitForSeconds(timeBetweenWaves);
        waitUntilNoEnemy = new WaitUntil(() => aliveEnemyList.Count == 0);
    }

    IEnumerator Start()
    {
        while (spawnEnemy)
        {
            yield return waitUntilNoEnemy;
            yield return waitTimeBetweenWaves;
            yield return StartCoroutine(nameof(RandomlySpawnsCoroutine));
        }
        
    }

    IEnumerator RandomlySpawnsCoroutine()
    {
        enemyAmount = Mathf.Clamp(enemyAmount, minEnemyAmount + waveNumber / 3, maxEnemyAmount);
        for (int i = 0; i < enemyAmount; i++)
        {
            aliveEnemyList.Add(PoolManager.Release(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]));
            
            yield return waitTimeBetweenSpawns;
        }
        waveNumber += 1;
    }

    public void RemoveFromAliveList(GameObject enemy) => aliveEnemyList.Remove(enemy);
}
