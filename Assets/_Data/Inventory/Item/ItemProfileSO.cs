using UnityEngine;

namespace _Data.Inventory.Item
{
    [CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfile", order = 1)]
    public class ItemProfileSo : ScriptableObject
    {
        public InventoryCodeName invCodeName;
        public ItemCode itemCode;
        public string itemName;
        public bool isStackable = false;

        protected void Reset()
        {
            this.ResetValue();
        }

        protected virtual void ResetValue()
        {
            this.AutoLoadItemCode();
            this.AutoLoadItemName();
        }

        protected virtual void AutoLoadItemCode()
        {
            string className = this.GetType().Name;
            Debug.Log("ClassName: "+className);
            this.itemCode = ItemCodeParse.Parse("Item1");
        }

        protected virtual void AutoLoadItemName()
        {
            Debug.Log("Name: " + this.name);
            this.itemName = "Item1";
        }
    }
}