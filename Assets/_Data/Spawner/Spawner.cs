using System.Collections.Generic;
using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Spawner
{
    public abstract class Spawner<T> : SinhMonoBehaviour where T : PoolObj
    {
        [SerializeField] protected int spawnCount = 0;
        [SerializeField] protected PoolHolder poolHolder;
    
        [SerializeField] protected PoolPrefabs<T> poolPrefabs;
        public PoolPrefabs<T> PoolPrefabs => this.poolPrefabs;
    
        [SerializeField] protected List<T> inPoolObjs;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPoolHolder();
            this.LoadPoolPrefabs();
        }
    
        protected virtual void LoadPoolHolder()
        {
            if (this.poolHolder != null) return;
            this.poolHolder = GetComponentInChildren<PoolHolder>();
            if (this.poolHolder == null)
            {
                this.poolHolder = new GameObject("PoolHolder").AddComponent<PoolHolder>();
                this.poolHolder.transform.SetParent(transform);
            }
            Debug.LogWarning(transform.name + ": LoadPoolHolder", gameObject);
        }

        protected virtual void LoadPoolPrefabs()
        {
            if (this.poolPrefabs != null) return;
            this.poolPrefabs = GetComponentInChildren<PoolPrefabs<T>>();
            Debug.Log(transform.name + ": LoadPoolPrefabs", gameObject);
        }

        public virtual Transform Spawn(Transform prefab)
        {
            Transform newObject = Instantiate(prefab);
            return newObject;
        }
    
        public virtual T Spawn(T prefab)
        {
            T newObj = this.GetObjectFromPool(prefab);
            if (newObj == null)
            {
                newObj = Instantiate(prefab);
                this.spawnCount++;
                this.UpdateName(prefab.transform, newObj.transform);
            }
            if(this.poolHolder != null) newObj.transform.SetParent(this.poolHolder.transform);
        
            return newObj;
        }

        public virtual T Spawn(T prefab, Vector3 position)
        {
            T newBullet = this.Spawn(prefab);
            newBullet.transform.position = position;
            return newBullet;
        }
    
        public virtual void Despawn(T obj)
        {
            if (obj is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.gameObject.SetActive(false);
                this.AddObjectToPool(obj);
            }
        
        }
    
        protected virtual void UpdateName(Transform prefab, Transform newObj)
        {
            newObj.name = prefab.name + "_" + this.spawnCount;
        }
    
        protected virtual void AddObjectToPool(T obj)
        {
            this.inPoolObjs.Add(obj);
        }

        protected virtual void RemoveObjectFromPool(T obj)
        {
            this.inPoolObjs.Remove(obj);
        }

        protected virtual T GetObjectFromPool(T prefab)
        {
            foreach (T inPoolObj in this.inPoolObjs)
            {
                if (prefab.GetName() == inPoolObj.GetName())
                {
                    this.RemoveObjectFromPool(inPoolObj);
                    return inPoolObj;
                }
            }

            return null;

        }
    }
}