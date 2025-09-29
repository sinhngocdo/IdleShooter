using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Object
{
    public class ObjSpawnerCtrl : SinhSingleton<ObjSpawnerCtrl>
    {
        [SerializeField] protected ObjSpawner objSpawner;
        public ObjSpawner ObjSpawner => this.objSpawner;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadObjSpawner();
        }
        
        protected virtual void LoadObjSpawner()
        {
            if (this.objSpawner != null) return;
            this.objSpawner = GetComponent<ObjSpawner>();
            Debug.Log(transform.name + ": LoadObjSpawner", gameObject);
        }
    }
}