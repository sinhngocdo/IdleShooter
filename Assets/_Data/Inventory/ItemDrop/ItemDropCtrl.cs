using _Data.Spawner;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ItemDropCtrl : PoolObj
    {
        [SerializeField] protected Rigidbody2D rigid2d;
        public Rigidbody2D Rigid2d => this.rigid2d;
        
        private ItemCode itemCode;
        public ItemCode ItemCode => this.itemCode;
        
        private int itemCount = 1;
        public int ItemCount => this.itemCount;
        
        public override string GetName()
        {
            return "ItemDrop";
        }
        
        public virtual void SetValue(ItemCode itemCode, int itemCount)
        {
            this.itemCode = itemCode;
            this.itemCount = itemCount;
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRigidbody();

        }
    
        protected virtual void LoadRigidbody()
        {
            if (this.rigid2d != null) return;
            this.rigid2d = GetComponent<Rigidbody2D>();
            Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
        }
    }
}