using _Data.CommonScripts;
using _Data.Spawner;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemyManager : SinhSingleton<EnemyManager>
    {
        [SerializeField] protected SpawnerEnemy enemySpawner;
        public SpawnerEnemy EnemySpawner => this.enemySpawner;
        
        [SerializeField] protected EnemyPrefabs enemyPrefabs;
        public EnemyPrefabs EnemyPrefabs => this.enemyPrefabs; 
        
        private int enemyKilledCount = 0;
        public int EnemyKilledCount => this.enemyKilledCount;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemySpawner();
            this.LoadEnemyPrefabs();
        }
        
        protected virtual void LoadEnemySpawner()
        {
            if (this.enemySpawner != null) return;
            this.enemySpawner = this.GetComponentInChildren<SpawnerEnemy>();
            Debug.LogWarning(transform.name + ": LoadEnemySpawner " , gameObject);
        }
        protected virtual void LoadEnemyPrefabs()
        {
            if (this.enemyPrefabs != null) return;
            this.enemyPrefabs = this.GetComponentInChildren<EnemyPrefabs>();
            Debug.LogWarning(transform.name + ": LoadEnemyPrefabs " , gameObject);
        }
        
        public virtual void AddEnemyKilledCount()
        {
            this.enemyKilledCount++;
        }
    }
}
