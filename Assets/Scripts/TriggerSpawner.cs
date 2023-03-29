using UnityEngine;
using UnityEngine.Events;

public class TriggerSpawner : MonoBehaviour
{
    [SerializeField] private UnityEvent _spawnPointEvent = new UnityEvent();

    public bool IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _spawnPointEvent.AddListener(value);
        remove => _spawnPointEvent.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsReached = true;
        _spawnPointEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsReached = false;
        _spawnPointEvent?.Invoke();
    }
}
