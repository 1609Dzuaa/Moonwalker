using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private static EventsManager _instance;
    private Dictionary<GameEnums.EEvents, Action<object>> _dictEvents = new();
    //Thêm sẵn các Action tương ứng với Event trong EnumEvents tại đây
    private Action<object> HatOnBeingThrew;
    private Action<object> HatOnBackToPlayer;

    public static EventsManager Instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<EventsManager>();

            if (!_instance)
                Debug.Log("0 co EventsManager trong Scene");

            return _instance;
        }
    }

    private void Awake()
    {
        CreateInstance();
        AddEventsToDictionary();
    }

    private void CreateInstance()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void AddEventsToDictionary()
    {
        _dictEvents.Add(GameEnums.EEvents.HatOnBeingThrew, HatOnBeingThrew);
        _dictEvents.Add(GameEnums.EEvents.HatOnBackToPlayer, HatOnBackToPlayer);
    }

    public void SubcribeToAnEvent(GameEnums.EEvents eventType, Action<object> function)
    {
        _dictEvents[eventType] += function;
    }

    public void UnSubcribeToAnEvent(GameEnums.EEvents eventType, Action<object> function)
    {
        _dictEvents[eventType] -= function;
    }

    public void NotifyObservers(GameEnums.EEvents eventType, object eventArgsType)
    {
        _dictEvents[eventType]?.Invoke(eventArgsType);
    }
}