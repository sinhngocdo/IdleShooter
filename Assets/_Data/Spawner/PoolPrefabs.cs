using System.Collections.Generic;
using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Spawner
{
    public abstract class PoolPrefabs<T> : SinhMonoBehaviour where T : PoolObj
    {
        [SerializeField] protected List<T> prefabs = new();
        public List<T> Prefabs => this.prefabs;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPrefabs();
            this.HidePrefabs();
        }
        
        protected virtual void LoadPrefabs()
        {
            if (this.prefabs.Count > 0) return;
            foreach (Transform child in transform)
            {
                T prefabCtrl = child.GetComponent<T>();
                if (prefabCtrl != null) this.prefabs.Add(prefabCtrl);
            }
            Debug.Log(transform.name + ": LoadPrefabs", gameObject);
        }
        
        protected virtual void HidePrefabs()
        {
            foreach (T prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }

        public virtual T GetRandom()
        {
            int rand = Random.Range(0, this.prefabs.Count);
            return this.prefabs[rand];
        }

        public virtual T GetByName(string prefabName)
        {
            foreach (T prefab in this.prefabs)
            {
                if (prefab.name != prefabName) continue;
                return prefab;
            }
            return null;
        }
    }
}