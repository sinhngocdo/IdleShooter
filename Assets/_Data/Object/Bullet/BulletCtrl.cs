using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Object.Bullet
{
    public class BulletCtrl : SinhMonoBehaviour
    {
        [SerializeField] protected Bullet bullet;
        public Bullet Bullet => this.bullet;
    
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBullet();
        }
    
        protected virtual void LoadBullet()
        {
            if(this.bullet != null) return;
            this.bullet = GetComponent<Bullet>();
            Debug.LogWarning(transform.name + ": LoadBullet", gameObject);       
        }
    }
}
