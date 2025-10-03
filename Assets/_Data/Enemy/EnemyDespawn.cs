using _Data.Spawner.Despawn;
using UnityEngine;

namespace _Data.Enemy
{
    public class EnemyDespawn : Despawn<EnemyCtrl>
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.isDespawnByTime = false;
        }
    }
}