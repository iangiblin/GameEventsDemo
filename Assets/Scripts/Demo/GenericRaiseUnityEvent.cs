using UnityEngine;

public class GenericRaiseUnityEvent : MonoBehaviour
{
    // this script is just to allow an additional layer to be imposed on
    // (say) a button, where we want a single event like OnClick to fan
    // out to multiple objects carrying the GameEventListener component.
    
    [Tooltip("Assign the event you want to broadcast")]
    [SerializeField] private GameEvent _gameEvent ;

    [ContextMenu("Fire off the event")]
    public void FireOffEvent()
    {
        Debug.Log($"{this} generating (Invoking) event {_gameEvent}");
        _gameEvent.Invoke();
    }
}
