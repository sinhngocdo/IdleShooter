using _Data.Damage;
using _Data.Inventory.ItemDrop;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

namespace _Data.Enemy
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField] protected CapsuleCollider capsuleCollider;
        [SerializeField] protected EnemyCtrl enemyCtrl;
        
        [Header("Despawn")]
        [SerializeField] protected float timeToDespawn = 1f;

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

        protected override void OnDead()
        {
            base.OnDead();
            this.enemyCtrl?.Enemy?.SetEnemyState(CharacterState.Death);
            this.capsuleCollider.enabled = false;
            this.enemyCtrl?.EnemyMoving?.SetCanMove(false);

            this.RewardOnDead();
            Invoke(nameof(this.Dissapear), this.timeToDespawn);
        }

        protected virtual void Dissapear()
        {
            this.enemyCtrl.Despawn.DoDespawn();
        }

        protected override void OnReborn()
        {
            base.OnReborn();
            this.capsuleCollider.enabled = true;
            this.enemyCtrl?.Enemy?.SetEnemyState(CharacterState.Ready);
            this.enemyCtrl?.EnemyMoving?.SetCanMove(true);
        }

        protected virtual void RewardOnDead()
        {
            ItemDropManager.Instance.DropMany(ItemCode.Gold, 5, this.transform.position);
        }
    }
}