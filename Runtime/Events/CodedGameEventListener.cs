using System;
using UnityEngine;

[Serializable]
public class CodedGameEventListener : IGameEventListener
{
   [SerializeField] private GameEvent @event;

   private Action m_onResponse;

   /// <inheritdoc />
   public void OnEventRaised()
   {
      m_onResponse?.Invoke();
   }

   public void OnEnable(Action response)
   {
      if (@event != null) @event.RegisterListener(this);
      m_onResponse = response;
   }

   public void OnDisable()
   {
      if (@event != null) @event.UnregisterListener(this);
      m_onResponse = null;
   }
}
