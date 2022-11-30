using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting};
    private bool hasSpawnedMeteorite = false;
    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemies;
    }

    public Wave[] waves;
    public Transform[] spawnpoints;

    private void Update()
    {
        StartCoroutine(SpawnWave(waves[0]));
    }

    IEnumerator SpawnWave(Wave wave)
    {
        while (true)
        {
            if (!hasSpawnedMeteorite)
            {
                SpawnEnemy(wave.enemies[Random.Range(0, wave.enemies.Length)].transform);
                hasSpawnedMeteorite = true;
                Invoke("SpawnNext", 3f);
            }
            yield return new WaitForSecondsRealtime(3f);
        }
    }

    void SpawnNext()
    {
        hasSpawnedMeteorite = false;
    }

    void SpawnEnemy(Transform Enemy)
    {
        Transform sp = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(Enemy, sp.position, Quaternion.identity);
    }
}
