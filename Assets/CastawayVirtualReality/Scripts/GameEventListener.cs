using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // Allows the event to be manually connected to other scripts and objects
    public GameEvent gameEvent;
    public UnityEvent onEventTriggered;

    // Subscribes a listener to an event
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    // Unsubcribes a listener to an event
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    // Invokes the event when called
    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
}

// Define event
// public GameEvent eventName;
// Trigger event
// eventName.TriggerEvent();
// Create new events by right-clicking in a folder, Create > Game Event(should be under XR)