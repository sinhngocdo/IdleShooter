using _Data.Damage;
using UnityEngine;

namespace _Data.Enemy
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected CapsuleCollider capsuleCollider;
        [SerializeField] protected EnemyCtrl enemyCtrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCapsuleCollider();
            this.LoadEnemyCtrl();
        }
        
        protected virtual void LoadCapsuleCollider()
        {
            if (this.capsuleCollider != null) return;
            this.capsuleCollider = this.GetComponent<CapsuleCollider>();
            this.capsuleCollider.center = new Vector3(0, 0.85f, 0);
            this.capsuleCollider.radius = 0.3f;
            this.capsuleCollider.height = 1.7f;
            this.capsuleCollider.isTrigger = true;
            Debug.Log(transform.name + "LoadCapsuleCollider", gameObject);
        }
    
        protected virtual void LoadEnemyCtrl()
        {
            if (this.enemyCtrl != null) return;
            this.enemyCtrl = this.GetComponentInParent<EnemyCtrl>();
            Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
        }
    }
}