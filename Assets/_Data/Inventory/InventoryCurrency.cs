using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryCurrency : InventoryCtrl
    {
        public override InventoryCodeName GetName()
        {
            return InventoryCodeName.Currency;
        }
    }
}