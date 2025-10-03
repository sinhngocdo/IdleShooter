using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Enemy.EnemyManager
{
    public class EnemyManagerAbstract : SinhMonoBehaviour
    {
        [SerializeField] protected EnemyManager enemyManager;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyManagerCtrl();
        }
        
        protected virtual void LoadEnemyManagerCtrl()
        {
            if (this.enemyManager != null) return;
            this.enemyManager = this.GetComponentInParent<EnemyManager>();
            Debug.LogWarning(transform.name + ": LoadEnemyManagerCtrl", gameObject);
        }
    }
}