using System;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private readonly int _finalWave = 10;
    private readonly float _timePerWave = 30f;
    private readonly float _pauseAtStartOfWave = 3f;

    private int _wave = 1;
    private float _timeThisWave = 0f;
    private float _currentSpawnRate = 1f;
    private float _spawnTimer = 0f;

    public Transform Monster1;
    public Transform Monster2;
    public Transform Monster3;
    public Transform Monster4;
    public Transform Monster5;
    public Transform Monster6;
    public Transform Monster7;
    public Transform Monster8;
    public Transform Monster9;
    public Transform Monster10;

    private TMP_Text Text;
    public GameObject Canvas;

    void Start()
    {
        Text = Canvas.GetComponent<TMP_Text>();
    }

    void Update()
    {
        UpdateCurrentWave();
        
        if (_wave > _finalWave)
        {
            return;
        }

        UpdateTimeThisWave();

        if (_timeThisWave < _pauseAtStartOfWave)
        {
            return;
        }

        Text.text = "Current wave: " + _wave + "\n" + "Time this wave: " + _timeThisWave;

        CalculateCurrentSpawnRate();

        HandleEnemySpawning();
    }

    private void HandleEnemySpawning()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _currentSpawnRate)
        {
            SpawnEnemy();

            _spawnTimer = 0f;
        }
    }

    private void UpdateTimeThisWave()
    {
        _timeThisWave = Time.timeSinceLevelLoad - _timePerWave * (_wave - 1);
    }

    private void UpdateCurrentWave()
    {
        _wave = (int)(Time.timeSinceLevelLoad / _timePerWave) + 1;
    }

    private void CalculateCurrentSpawnRate()
    {
        var maxSpawnRateForWave = 1f - 0.1f * _wave;
        maxSpawnRateForWave = Math.Max(maxSpawnRateForWave, 0.05f);

        var minSpawnRateForWave = 1f - 0.05f * _wave;

        _currentSpawnRate = Mathf.Lerp(minSpawnRateForWave, maxSpawnRateForWave, _timeThisWave / _timePerWave);
    }

    private void SpawnEnemy()
    {
        var enemyToSpawn = GetEnemyToSpawn();

        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    private Transform GetEnemyToSpawn()
    {
        return _wave switch
        {
            1 => Monster1,
            2 => Monster2,
            3 => Monster3,
            4 => Monster4,
            5 => Monster5,
            6 => Monster6,
            7 => Monster7,
            8 => Monster8,
            9 => Monster9,
            10 => Monster10,
            _ => Monster1,
        };
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float screenX = UnityEngine.Random.Range(0f, 1f);
        float screenY = UnityEngine.Random.Range(0f, 1f);
        Vector3 spawnPosition = Vector3.zero;

        if (screenX < 0.5f)
        {
            // Spawn on the left or right edge
            spawnPosition.x = screenX < 0.25f
                ? -Camera.main.aspect * Camera.main.orthographicSize
                : Camera.main.aspect * Camera.main.orthographicSize;

            spawnPosition.y = Camera.main.orthographicSize * (screenY * 2f - 1f);
        }
        else
        {
            // Spawn on the top or bottom edge
            spawnPosition.x = Camera.main.aspect * Camera.main.orthographicSize * (screenX * 2f - 1f);

            spawnPosition.y = screenY < 0.25f
                ? -Camera.main.orthographicSize
                : Camera.main.orthographicSize;
        }

        return spawnPosition;
    }
}
