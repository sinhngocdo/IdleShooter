using _Data.Spawner;
using UnityEngine;

namespace _Data.Object.Bullet
{
    public class Bullet : PoolObj
    {
        [Header("Bullet Abstract")]
        [SerializeField] protected BulletCtrl bulletCtrl;

        public BulletCtrl BulletCtrl { get => bulletCtrl; }

        public override string GetName()
        {
            return "Bullet";
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBulletCtrl();
        }

        protected virtual void LoadBulletCtrl()
        {
            if (this.bulletCtrl != null) return;
            this.bulletCtrl = transform.GetComponent<BulletCtrl>();
            Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
        }
    }
}
