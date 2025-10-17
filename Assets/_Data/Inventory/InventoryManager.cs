using System.Collections.Generic;
using _Data.CommonScripts;
using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryManager : SinhSingleton<InventoryManager>
    {
        [SerializeField] protected List<InventoryCtrl> inventories;
        [SerializeField] protected List<ItemProfileSo> itemProfiles;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInventories();
            this.LoadItemProfiles();
        }
        
        protected virtual void LoadInventories()
        {
            if (this.inventories.Count > 0) return;
            foreach (Transform child in transform)
            {
                InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
                if (inventoryCtrl == null) continue; 
                this.inventories.Add(inventoryCtrl);
            }
            Debug.Log(transform.name + ": LoadInventories", gameObject);
        }

        protected virtual void LoadItemProfiles()
        {
            if (this.itemProfiles.Count > 0) return;
            string filePath = "SO/ItemProfiles";
        
            ItemProfileSo[] loadedItemProfiles = Resources.LoadAll<ItemProfileSo>(filePath);
            this.itemProfiles = new List<ItemProfileSo>(loadedItemProfiles);
            Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
        }
        
        public virtual InventoryCtrl GetByCodeName(InventoryCodeName inventoryName)
        {
            foreach (InventoryCtrl inventory in this.inventories)
            {
                if (inventory.GetName() == inventoryName) return inventory;
            }

            return null;
        }
    
        public virtual ItemProfileSo GetProfileByCode(ItemCode itemCodeName)
        {
            foreach (ItemProfileSo itemProfile in this.itemProfiles)
            {
                if (itemProfile.itemCode == itemCodeName) return itemProfile;
            }

            return null;
        }
        
        public virtual InventoryCtrl Currency()
        {
            return this.GetByCodeName(InventoryCodeName.Currency);
        }

        public virtual InventoryCtrl Items()
        {
            return this.GetByCodeName(InventoryCodeName.Items);
        }
    
        public virtual void AddItem(ItemInventory itemInventory)
        {
            InventoryCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
            InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
            inventoryCtrl.AddItem(itemInventory);
        }
        
        public virtual void AddItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSo itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.AddItem(item);
        }

        public virtual void RemoveItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSo itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.RemoveItem(item);
        }
        public virtual void RemoveItem(ItemInventory itemInventory)
        {
            InventoryCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
            InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
            inventoryCtrl.RemoveItem(itemInventory);
        }
    }
}