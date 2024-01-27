using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : Singleton<EventsManager>
{
    public Dictionary<GameEnums.EEvents, Action<object>> _dictEvents = new();

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SubcribeToAnEvent(GameEnums.EEvents eventType, Action<object> function)
    {
        if (!_dictEvents.ContainsKey(eventType))
        {
            _dictEvents.Add(eventType, function);
        }
        else
            _dictEvents[eventType] += function;
    }

    public void UnSubcribeToAnEvent(GameEnums.EEvents eventType, Action<object> function)
    {
        _dictEvents[eventType] -= function;
    }

    public void NotifyObservers(GameEnums.EEvents eventType, object eventArgsType)
    {
        if (_dictEvents.ContainsKey(eventType))
            _dictEvents[eventType]?.Invoke(eventArgsType);
    }
}