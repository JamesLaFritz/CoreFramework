#region Description

// ----------------------------------------------------------------------------
// Came from
// https://github.com/roboryantron/Unite2017
//
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

#endregion

using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    [InfoBox("Game Event to Listen to.")]
    [Tooltip("Event to register with.")]
    [SerializeField]
    private GameEvent @event;

    [Tooltip("Response to invoke when Event is raised.")]
    [InfoBox("Unity Events to preform when the Game Event is Raised")]
    [SerializeField]
    private UnityEvent response;

    public void OnEnable()
    {
        if (@event != null) @event.RegisterListener(this);
    }

    public void OnDisable()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
