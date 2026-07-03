using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public GameManager gameManager;

    public Wave[] waves;

    [SerializeField] private Transform spawnPoint;
    

    [SerializeField] private float timeBetweenWaves = 5f;

    private float countDown = 5f;

    [SerializeField] private TextMeshProUGUI waveCountdownTimer;

    private int indexWave = 0;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    private void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (indexWave == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:0.00}", countDown);
    }

    private IEnumerator SpawnWave()
    {

        
        PlayerStats.rounds++;

        Wave wave = waves[indexWave];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        indexWave++;
        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
}
