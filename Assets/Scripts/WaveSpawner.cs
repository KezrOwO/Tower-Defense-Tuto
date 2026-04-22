using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    

    [SerializeField] private float timeBetweenWaves = 5f;

    private float countDown = 2f;

    [SerializeField] private TextMeshProUGUI waveCountdownTimer;

    private int indexWave = 0;

    private void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        waveCountdownTimer.text = Mathf.Round(countDown).ToString();
    }

    private IEnumerator SpawnWave()
    {

        indexWave++;

        for (int i = 0; i < indexWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
