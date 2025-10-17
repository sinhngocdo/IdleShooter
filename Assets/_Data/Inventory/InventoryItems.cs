using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryItems : InventoryCtrl
    {
        public override InventoryCodeName GetName()
        {
            return InventoryCodeName.Items;
        }
    }
}