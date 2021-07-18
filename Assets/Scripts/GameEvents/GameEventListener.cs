using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // this sits on a gameobject (e.g. a cube) and allows you to pick up
    // the specific event when it is broadcast.
    
    [SerializeField] private UnityEvent _unityEvent;
    [SerializeField] private GameEvent _gameEvent;

    private void Awake() => _gameEvent.Register(this);

    public void HandleGameEvent()
    {
        Debug.Log($"GameEventListener {this.name} invoking {_unityEvent}");
        _unityEvent.Invoke();
    }

    private void OnDisable() => _gameEvent.Deregister(this);
}