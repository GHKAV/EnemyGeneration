using System.Collections;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    private SpawnPoint[] _spawnPoints;
    private Coroutine _spawnEnemiesCoroutine;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(2);
    private bool IsReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsReached = true;
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsReached = false;
        StopCoroutine(_spawnEnemiesCoroutine);
    }

    private IEnumerator SpawnEnemies()
    {
        while (IsReached)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnPoints[i].SpawnEnemies();
                yield return _waitForSeconds;
            }
        }
    }
}
