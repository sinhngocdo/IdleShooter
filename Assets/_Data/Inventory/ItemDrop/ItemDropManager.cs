using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    public class ItemDropManager : SinhSingleton<ItemDropManager>
    {
        [SerializeField] protected ItemDropSpawner itemDropSpawner;
        public ItemDropSpawner ItemDropSpawner => itemDropSpawner;
        
        protected float spawnHeight = 1f;
        protected float froceAmount = 2f;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadItemDropSpawner();
        }
     
        protected virtual void LoadItemDropSpawner()
        {
            if (this.itemDropSpawner != null) return;
            this.itemDropSpawner = GetComponent<ItemDropSpawner>();
            Debug.LogWarning(transform.name + ": LoadItemDropSpawner", gameObject);
        }
        
        public virtual void DropMany(ItemCode itemCode, int dropCount, Vector3 dropPosition)
        {
            for (int i = 0; i < dropCount; i++)
            {
                this.DropItem(itemCode, 1, dropPosition);
            }
        }
        
        public virtual void DropItem(ItemCode itemCode, int dropCount, Vector3 dropPosition)
        {
            Vector3 dropPositionOffset = dropPosition + new Vector3(Random.Range(-2,2), spawnHeight, Random.Range(-2,2));
            ItemDropCtrl itemPrefab = this.itemDropSpawner.PoolPrefabs.GetByName(itemCode.ToString());
            if(itemPrefab == null) itemPrefab = this.itemDropSpawner.PoolPrefabs.GetByName("DefaultDrop");

            ItemDropCtrl newItem = this.itemDropSpawner.Spawn(itemPrefab, dropPositionOffset);
            newItem.SetValue(itemCode, dropCount);
            newItem.gameObject.SetActive(true);
          
            Vector3 randomDirection = Random.onUnitSphere;
            randomDirection.y = Mathf.Abs(randomDirection.y);
            newItem.Rigid2d.AddForce(randomDirection * froceAmount, ForceMode2D.Impulse);
        }
    }
}