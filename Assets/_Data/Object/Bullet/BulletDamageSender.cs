using UnityEngine;

namespace _Data.Object.Bullet
{
    [RequireComponent(typeof(SphereCollider))]
    public class BulletDamageSender : DamageSender
    {
        [Header("Bullet Damage Sender")]
        [SerializeField] protected SphereCollider sphereCollider;
        [SerializeField] protected BulletCtrl bulletCtrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
            this.BulletCtrl();
        }
    
        protected virtual void LoadSphereCollider()
        {
            if(this.sphereCollider != null) return;
            this.sphereCollider = this.GetComponent<SphereCollider>();
            this.sphereCollider.radius = 0.05f;
            this.sphereCollider.isTrigger = true;
            Debug.Log(transform.name + "LoadSphereCollider", gameObject);
        }
    
        protected virtual void BulletCtrl()
        {
            if(this.bulletCtrl != null) return;
            this.bulletCtrl = this.transform.parent.GetComponent<BulletCtrl>();
            Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
        }
    
        protected override void Send(DamageReceiver damageReceiver)
        {
            base.Send(damageReceiver);
            this.bulletCtrl.Bullet.Despawn.DoDespawn();
        }
    }
}