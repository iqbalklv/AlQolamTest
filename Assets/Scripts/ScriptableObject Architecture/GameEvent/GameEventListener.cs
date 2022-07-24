using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent listenedEvent = default;
    [SerializeField] private UnityEvent response = default;

    public void OnEventRaised()
    {
        response.Invoke();
    }

    private void OnEnable()
    {
        listenedEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        listenedEvent.UnregisterListener(this);
    }

    public UnityEvent GetResponse()
    {
        return response;
    }
}
