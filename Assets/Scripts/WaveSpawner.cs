using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Attributes")]
    public float TimeBetweenWaves = 5f;
    public int MaxNumberOfWaves = 4;

    [Header("Unity Setup Fields")]
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public Text WaveCountdownText;

    private float _countdown = 2f;  // Time for initial Spawn
    private int _waveIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waveIndex >= MaxNumberOfWaves)
        {
            //WaveCountdownText.text = "Final Wave";
            return;
        }

        // Decrement countdown by frame time
        _countdown -= Time.deltaTime;
        WaveCountdownText.text = Math.Max(Mathf.FloorToInt(_countdown), 0).ToString();

        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            // Reset countdown
            _countdown = TimeBetweenWaves;
        }
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;

        Debug.Log($"Spawn Wave number {_waveIndex}");
        for (int index = 0; index < _waveIndex; index++)
        {
            Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);

            // Delay for 0.5s
            yield return new WaitForSeconds(0.5f);
        }
    }
}
