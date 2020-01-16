using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyBase;
    public float spawnGrace;

    public Wave[] waves;
    public int waveNumber;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaveLoop(waves[waveNumber]));
            waveNumber++;
        }
    }

    IEnumerator WaveLoop(Wave waveToSpawn)
    {
        for (int i = 0; i < waveToSpawn.enemyTypes.Count; i++)
        {
            for (int x = 0; x < waveToSpawn.enemyQuantities[i]; x++)
            {
                SpawnEnemy(waveToSpawn.enemyTypes[i]);
                yield return new WaitForSeconds(spawnGrace);
            }
        }
    }

    private void SpawnEnemy(EnemySO eSO)
    {
        GameObject eToSpawn = Instantiate(enemyBase, transform.position, Quaternion.identity);
        eToSpawn.GetComponent<EnemyController>().SO = eSO;
    }
}
