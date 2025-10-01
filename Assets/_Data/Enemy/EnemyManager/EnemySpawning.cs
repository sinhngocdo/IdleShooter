using System.Collections.Generic;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemySpawning : EnemyManagerAbstract
    {
        [SerializeField] protected int maxSpawn = 10;
        [SerializeField] protected float spawnSpeed = 1f;
        [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();
        
        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.Spawning),this.spawnSpeed);
        }


        protected virtual void Spawning()
        {
            Invoke(nameof(this.Spawning),this.spawnSpeed);
            this.RemoveDeadOne();
            if (this.spawnedEnemies.Count >= this.maxSpawn) return;
            EnemyCtrl prefab = this.GetEnemyPrefab();
          
            EnemyCtrl newEnemy = this.enemyManager.EnemySpawner.Spawn(prefab, transform.position);
            newEnemy.gameObject.SetActive(true);
          
            this.spawnedEnemies.Add(newEnemy);
        }
     
        protected virtual EnemyCtrl GetEnemyPrefab()
        {
            return this.enemyManager.EnemyPrefabs.GetRandom();
        }

        protected virtual void RemoveDeadOne()
        {
            foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
            {
                if (enemyCtrl.EnemyDamageReceiver.IsDead())
                {
                    this.spawnedEnemies.Remove(enemyCtrl);
                    return;
                }
            }
        }
    }
}