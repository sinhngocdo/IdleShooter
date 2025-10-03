using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ItemPicker : SinhMonoBehaviour
    {
        [SerializeField] protected CircleCollider2D circleCollider2D;
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
        }

        protected virtual void LoadSphereCollider()
        {
            if(this.circleCollider2D != null) return;
            this.circleCollider2D = this.GetComponent<CircleCollider2D>();
            this.circleCollider2D.radius = 0.3f;
            this.circleCollider2D.isTrigger = true;
            Debug.LogWarning(transform.name + ": LoadSphereCollider", gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent == null) return;
            ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
            if (itemDropCtrl == null) return;
            itemDropCtrl.Despawn.DoDespawn();
        }
    }
}