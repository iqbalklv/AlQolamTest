using System.Collections.Generic;
using BasicTools.ButtonInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableLibrary/Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    [Button("Debug Listeners", nameof(DebugListeners))]
    public bool debugListenerButton;
    private void DebugListeners()
    {
        string listenerGameObjects = $"{this.name} GameEvent's Listeners:\n";
        foreach (var listener in listeners)
        {
            listenerGameObjects += $"{listener.gameObject.name}\n";
        }
        Debug.Log(listenerGameObjects);
    }

    [Button("Debug Raise", nameof(Raise))]
    public bool debugRaiseButton;
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
