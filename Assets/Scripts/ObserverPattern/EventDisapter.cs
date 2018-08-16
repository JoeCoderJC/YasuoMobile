using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EventID
{
    None = 0,
    OnAttack
}

public class EventDispatcher : MonoBehaviour {

    Dictionary<EventID, Action<object>> listeners = new Dictionary<EventID, Action<object>>();

    //Singleton
    public static EventDispatcher Instance { get; set; }

    private void Awake()
    {
        MakeSingleInstance();
    }

    void MakeSingleInstance()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterListener(EventID eventID, Action<object> callback)
    {
        // check if listener exist in distionary
        if (listeners.ContainsKey(eventID))
        {
            // add callback to our collection
            listeners[eventID] += callback;
        }
        else
        {
            // add new key-value pair
            listeners.Add(eventID, null);
            listeners[eventID] += callback;
        }
    }

    public void PostEvent(EventID eventID, object param = null)
    {
        // posting event
        var callbacks = listeners[eventID];
        // if there's no listener remain, then do nothing
        if (callbacks != null)
        {
            callbacks(param);
        }
        else
        {
            listeners.Remove(eventID);
        }
    }

    public void RemoveListener(EventID eventID, Action<object> callback)
    {
        if (listeners.ContainsKey(eventID))
        {
            listeners[eventID] -= callback;
        }
    }

    public void ClearAllListener()
    {
        listeners.Clear();
    }

}

public static class EventDispatcherExtension
{
    public static void RegisterListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
    {
        EventDispatcher.Instance.RegisterListener(eventID, callback);
    }

    // Post event with param
    public static void PostEvent(this MonoBehaviour listener, EventID eventID, object param)
    {
        EventDispatcher.Instance.PostEvent(eventID, param);
    }

    // Post event with no param (param = null)
    public static void PostEvent(this MonoBehaviour sender, EventID eventID)
    {
        EventDispatcher.Instance.PostEvent(eventID, null);
    }
}
