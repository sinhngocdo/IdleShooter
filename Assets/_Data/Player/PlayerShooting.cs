
using _Data.Object.Bullet;
using UnityEngine;

namespace _Data.Player
{
    public class PlayerShooting : PlayerAbstract
    {
        [SerializeField] protected float shootSpeed = 0.2f;
        [SerializeField] protected FirePoint firePoint;


        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.Shooting), this.shootSpeed);
            this.LoadFirePoint();
        }
        

        protected virtual void LoadFirePoint()
        {
            if(this.firePoint != null) return;
            this.firePoint = FindObjectOfType<FirePoint>();
            Debug.LogWarning(transform.name + ": LoadFirePoint", gameObject);
        }

        protected virtual void Shooting()
        {
            Invoke(nameof(this.Shooting), this.shootSpeed);
            
            Vector3 direction = this.playerCtrl.transform.forward;

            this.SpawnBullet(firePoint.transform.position, direction);
        }

        protected virtual void SpawnBullet(Vector3 spawnPoint, Vector3 direction)
        {
            Bullet newBullet = this.playerCtrl.BulletSpawner.Spawn(this.playerCtrl.Bullet, spawnPoint);
            newBullet.transform.forward = direction;
            newBullet.gameObject.SetActive(true);
        }
        
        
    }
}
