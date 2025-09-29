using UnityEngine;

namespace _Data.CommonScripts
{
    public abstract class SinhSingleton<T> : SinhMonoBehaviour where T : SinhMonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if(_instance == null) Debug.LogError("Singleton instance has not been created yet!");
                return _instance;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.LoadInstance();
        }

        public static bool HasInstance()
        {
            return _instance != null;
        }

        protected virtual void LoadInstance()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if(transform.parent == null) DontDestroyOnLoad(this.gameObject);
                return;
            }
            if(_instance != this) Debug.LogError("Singleton instance has not been created yet!");
        }
    }
}