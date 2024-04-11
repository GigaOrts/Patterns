using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBus
{
    public class EventBus : MonoBehaviour
    {
        private static readonly
            IDictionary<GameEventType, UnityEvent>
            Events = new Dictionary<GameEventType, UnityEvent>();

        public static void Subscribe(GameEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(GameEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(GameEventType eventType)
        {
            if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}

