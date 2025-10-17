using System;
using UnityEngine;

namespace _Data.Inventory.Item
{
    [Serializable]
    public class ItemInventory
    {
        protected int itemId;
        public int ItemID => itemId;
    
        protected ItemProfileSo itemProfile;
        public ItemProfileSo ItemProfile => itemProfile;
    
        [SerializeField] protected string itemName;

        public int itemCount;

        public ItemInventory(ItemProfileSo itemProfile, int itemCount)
        {
            this.itemProfile = itemProfile;
            this.itemCount = itemCount;
            this.itemName = this.itemProfile.itemName;
        }
        public virtual void SetId(int id)
        {
            this.itemId = id;
        }
        public virtual void SetName(string name)
        {
            this.itemName = name;
        }
        public virtual string GetItemName()
        {
            if (String.IsNullOrEmpty(this.itemName)) return this.itemProfile.itemName;
            return this.itemName;
        }
    
        public virtual bool Deduct(int number)
        {
            if (!CanDeduct(number)) return false;
            this.itemCount -= number;
            return true;
        }

        public virtual bool CanDeduct(int number)
        {
            return this.itemCount >= number;
        }
    }
}