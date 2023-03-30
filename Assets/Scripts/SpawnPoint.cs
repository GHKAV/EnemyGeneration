using UnityEngine;

[RequireComponent(typeof(SpawnPoint))]

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    public void SpawnEnemies()
    {
        Instantiate(_template, transform.position, Quaternion.identity);
    }
}
