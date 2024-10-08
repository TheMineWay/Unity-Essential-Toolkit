using EssentialToolkit.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EssentialToolkit.Dialogs
{
    public delegate void OnDialogEventCalled(string eventId);
    public class DialogEventsProvider : AInitializer
    {
        #region Static event providers store

        private static List<DialogEventsProvider> providers = new();
        public static OnDialogEventCalled onDialogEventCalled;

        #endregion

        [SerializeField]
        [Header("Events by its id")]
        private UnityEventDictionaryBuilder[] _events;

        #region Events state

        private Dictionary<string, UnityEvent> events;

        #endregion

        #region Initialization
        public override void Initialize()
        {
            events = UnityEventDictionaryBuilder.ToDictionary(_events);
            
            lock(providers) providers.Add(this);
        }

        private void OnDestroy()
        {
            providers.Remove(this);
        }

        #endregion

        #region Internal API

        private void _Invoke(string eventId, bool callDelegateEventsListener = true)
        {
            if (callDelegateEventsListener) onDialogEventCalled?.Invoke(eventId);

            if (!events.ContainsKey(eventId)) return;

            var ev = events[eventId];
            ev.Invoke();
        }

        #endregion

        #region API

        public void Invoke(string eventId) => _InvokeEvent(eventId);

        #endregion

        #region Internal static API

        private static void _InvokeEvent(string eventId)
        {
            bool callEventDelegate = true;
            foreach (var provider in providers)
            {
                provider._Invoke(eventId, callDelegateEventsListener: callEventDelegate);
                callEventDelegate = false;
            }
        }

        #endregion

        #region Static API

        public static void InvokeEvent(string eventId) => _InvokeEvent(eventId);

        public static void InvokeEvents(string[] eventIds)
        {
            if (eventIds == null) return;
            foreach (var eventId in eventIds) InvokeEvent(eventId);
        }

        #endregion
    }
}