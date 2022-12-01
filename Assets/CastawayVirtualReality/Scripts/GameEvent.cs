using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows for the creation of new scriptableobject assets to use for the game event system
[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    // List for subscribed listeners
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    // Allows a listener to subscribe to the list
    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    // Allows a listener to unsubscribe to the list
    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}