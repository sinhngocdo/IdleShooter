using _Data.CommonScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

namespace _Data.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMoving : SinhMonoBehaviour
    {
        [SerializeField] protected EnemyCtrl enemyCtrl;
        [SerializeField] protected Rigidbody2D rigid2D;
        [SerializeField] protected float stopDistance = 2f;
        [SerializeField] protected float moveSpeed = 1f;
        [SerializeField] protected bool canMove = true;
        [SerializeField] protected bool isMoving = true;
        
        
        protected virtual void FixedUpdate()
        {
            this.Moving();
            this.CheckMoving();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyCtrl();
            this.LoadRigid2D();
        }

        protected virtual void LoadRigid2D()
        {
            if (this.rigid2D != null) return;
            this.rigid2D = this.GetComponent<Rigidbody2D>();
            Debug.Log(transform.name + ": LoadRigid2D", gameObject);       
        }
        
        protected virtual void LoadEnemyCtrl()
        {
            if (this.enemyCtrl != null) return;
            this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
            Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
        }
        
        protected virtual void Moving()
        {
            if (!this.canMove)
            {
                this.enemyCtrl.Enemy.SetEnemyState(CharacterState.Ready);
            }

            this.rigid2D.velocity = new Vector2(-moveSpeed, this.rigid2D.velocity.y);
        }
        protected virtual void CheckMoving()
        {
            this.isMoving = this.rigid2D.velocity.magnitude > 0.1f;
            this.enemyCtrl.Enemy.SetEnemyState(CharacterState.Walk);
        }
        
    }
}
