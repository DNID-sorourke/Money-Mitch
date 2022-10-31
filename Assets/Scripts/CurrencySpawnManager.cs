using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _allCurrencies;

    public int WaveSizeMinimum;
    public int WaveSizeMaximum;

    public float TimeBetweenWaves;
    public float TimeSinceLastWave;

    [SerializeField] private BoxCollider2D _spawnArea; // this just an off-screen spawn box

    void Update()
    {
        TimeSinceLastWave += Time.deltaTime;
        if (TimeSinceLastWave >= TimeBetweenWaves)
        {
            SpawnWave();
            TimeSinceLastWave = 0;
        }
    }

    private void SpawnWave()
    {
        int waveSize = Random.Range(WaveSizeMinimum, WaveSizeMaximum);

        for (int i = 0; i < waveSize; i++)
        {
            SpawnCurrency();
        }
    }

    private void SpawnCurrency()
    {
        float spawnX = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
        float spawnY = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);

        int currencyIdx = Random.Range(0, _allCurrencies.Length);

        Instantiate(_allCurrencies[currencyIdx], new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
