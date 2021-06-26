using System;
using System.Collections.Generic;
using UnityEngine;

// this allows us to make new GameEvents from the menu.
[CreateAssetMenu(menuName = "Game Event")]

public class GameEvent : ScriptableObject
{
    private static HashSet<GameEvent> _listenedEvents = new HashSet<GameEvent>();
    private HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener>();

    public void Register(GameEventListener gameEventListener)
    {
        _gameEventListeners.Add(gameEventListener);
        _listenedEvents.Add(this);
    }

    public void Deregister(GameEventListener gameEventListener)
    {
        _gameEventListeners.Remove(gameEventListener);
        if (_gameEventListeners.Count == 0)
        {
            _listenedEvents.Remove(this);
        }
    }

    // this is on each individual event e.g. OpenDoor
    [ContextMenu("Invoke")]
    public void Invoke()
    {
        Debug.Log($"GameEvent {this.name} calling RaiseEvent");
        foreach (var gameEventListener in _gameEventListeners)
        {
            gameEventListener.RaiseEvent();
        }
    }

    // static method - send message to all listeners, called from
    // some other object like a button, GameEvent.RaiseEvent(eventName);
    public static void RaiseEvent(string eventName)
    {
        foreach (var gameEvent in _listenedEvents)
        {
            if (gameEvent.name == eventName)
            {
                gameEvent.Invoke();
            }
        }
    }
}
