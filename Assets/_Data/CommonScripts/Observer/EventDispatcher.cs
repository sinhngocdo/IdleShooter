using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Data.CommonScripts.Observer
{
    public class EventDispatcher : SinhSingleton<EventDispatcher>
    {
        private static readonly Dictionary<EventID, Action<object>> _listeners = new();

        public void RegisterListener(EventID eventID, Action<object> callback)
        {
            // check if a listener exists in distionary
            if (_listeners.ContainsKey(eventID))
            {
                // add callback to our collection
                _listeners[eventID] += callback;
            }
            else
            {
                // add a new key-value pair
                _listeners.Add(eventID, null);
                _listeners[eventID] += callback;
            }
        }
        
        public void RemoveListener(EventID eventID, Action<object> callback)
        {
            if (_listeners.ContainsKey(eventID))
            {
                _listeners[eventID] -= callback;
            }
            else
            {
                Debug.Log("RemoveListener , but no listener remain "+ eventID);
            }
        }
        
        
        public void PostEvent(EventID eventID, object param = null)
        {
            if (!_listeners.ContainsKey(eventID))
            {
                Debug.Log("No listener for this eventID:"+ eventID);
                return;
            }

            // posting event
            var callbacks = _listeners[eventID];
            // if there's no listener remain, then do nothing
            if (callbacks != null)
            {
                callbacks(param);
            }
            else
            {
                Debug.Log("PostEvent , but no listener remain, Remove this key"+ eventID);
                _listeners.Remove(eventID);
            }
        }
        
        public void ClearAllListener()
        {
            _listeners.Clear();
        }

        private void OnDestroy()
        {
            if(Instance == this) this.ClearAllListener();
        }
    }

    #region Extension Class
    /// <summary>
    /// Delare some shortcut for using EventDispatcher
    /// </summary>
    public static class EventDispatcherExtension
    {
        public static void RegisterListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
        {
            EventDispatcher.Instance.RegisterListener(eventID, callback);
        }
        
        public static void RemoveListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
        {
            EventDispatcher.Instance.RemoveListener(eventID, callback);
        }
        //Post event with param
        public static void PostEvent(this MonoBehaviour sender, EventID eventID, object param)
        {
            EventDispatcher.Instance.PostEvent(eventID, param);
        }

        public static void PostEvent(this MonoBehaviour sender, EventID eventID)
        {
            EventDispatcher.Instance.PostEvent(eventID, null);
        }
    }
    #endregion
    
}