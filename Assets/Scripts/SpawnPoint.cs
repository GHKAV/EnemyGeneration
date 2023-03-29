using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private TriggerSpawner _triggerSpawner;
    private Enemy _template;
    private SpawnPoint[] _spawnPoints;
    private Coroutine _spawnEnemiesCoroutine;

    private void OnEnable()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
        _template = Resources.Load<Enemy>("Daemon");
        _triggerSpawner = FindObjectOfType<TriggerSpawner>();
        _triggerSpawner.Reached += StartCoroutine;
    }

    private void OnDisable()
    {
        _triggerSpawner.Reached -= StartCoroutine;
    }

    private void StartCoroutine()
    {
        if (_spawnEnemiesCoroutine != null)
        {
            StopCoroutine(_spawnEnemiesCoroutine);
        }

        _spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_triggerSpawner.IsReached)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_template, _spawnPoints[i].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2);
            }
        }
    }
}
