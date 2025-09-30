using _Data.CommonScripts;
using _Data.Object.Bullet;
using _Data.Spawner;
using UnityEngine;

namespace _Data.Enemy
{
    public class EnemyCtrl : PoolObj
    {
        [SerializeField] protected Enemy enemy;
        public Enemy Enemy => this.enemy;
        
        [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
        public EnemyDamageReceiver EnemyDamageReceiver => this.enemyDamageReceiver;

        public override string GetName()
        {
            return "Enemy_1";
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemy();
            this.LoadDamageReceiver();
        }
    
        protected virtual void LoadEnemy()
        {
            if(this.enemy != null) return;
            this.enemy = GetComponent<Enemy>();
            Debug.LogWarning(transform.name + ": LoadEnemy", gameObject);       
        }
        
        protected virtual void LoadDamageReceiver()
        {
            if (this.enemyDamageReceiver != null) return;
            this.enemyDamageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
            Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
        }
    }
}
