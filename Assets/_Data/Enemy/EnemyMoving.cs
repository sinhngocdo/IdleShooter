using _Data.CommonScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

namespace _Data.Enemy
{
    public class EnemyMoving : SinhMonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected EnemyCtrl enemyCtrl;
        [SerializeField] protected Rigidbody2D rigid2D;
        [SerializeField] protected Transform target;
        
        [Header("Movement")]
        [SerializeField] protected float stopDistance = 2f;
        [SerializeField] protected float moveSpeed = 1f;
        [SerializeField] protected bool canMove = true;
        
        [Header("Runtime")]
        [SerializeField] protected bool isMoving = false;
        [SerializeField] protected float distance = 0f;
        
        
        
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
            this.LoadTarget();
        }

        protected virtual void LoadRigid2D()
        {
            if (this.rigid2D != null) return;
            this.rigid2D = this.GetComponentInParent<Rigidbody2D>();
            this.rigid2D.gravityScale = 0;
            this.rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            Debug.Log(transform.name + ": LoadRigid2D", gameObject);       
        }
        
        protected virtual void LoadEnemyCtrl()
        {
            if (this.enemyCtrl != null) return;
            this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
            Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
        }

        protected virtual void LoadTarget()
        {
            if(this.target != null) return;
            this.target = GameObject.FindObjectOfType<PlayerCtrl>().transform;
            Debug.Log(transform.name + ": LoadTarget", gameObject);
        }
        
        protected virtual void Moving()
        {
            if (!this.canMove)
            {
                this.StopMoving();
                return;
            }

            if (this.CheckDistance())
            {
                this.StopMoving();
                this.enemyCtrl.Enemy.SetEnemyState(CharacterState.Ready);
                return;
            }

            this.rigid2D.velocity = new Vector2(-moveSpeed, this.rigid2D.velocity.y);
            this.enemyCtrl.Enemy.SetEnemyState(CharacterState.Walk);
        }
        protected virtual void CheckMoving()
        {
            this.isMoving = this.rigid2D.velocity.magnitude > 0.1f;
        }

        protected virtual bool CheckDistance()
        {
            this.distance = Mathf.Abs(Vector2.Distance(this.transform.position, this.target.position));
            if (this.distance <= this.stopDistance)
            {
                return true;
            }
            return false;
        }

        protected virtual void StopMoving()
        {
            if (Mathf.Abs(this.rigid2D.velocity.x) > 0.0001f)
                this.rigid2D.velocity = new Vector2(0f, this.rigid2D.velocity.y);
        }

        public virtual void SetCanMove(bool isCanMove)
        {
            this.canMove = isCanMove;
            if(!this.canMove) this.StopMoving();
        }
        
    }
}
