using _Data.CommonScripts;
using _Data.Spawner;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

namespace _Data.Enemy
{
    public class Enemy : SinhMonoBehaviour
    {
        [Header("Character Ctrl")] 
        [SerializeField] protected Character4D character;
        [Header("Enemy Abstract")]
        [SerializeField] protected EnemyCtrl enemyCtrl;
        public EnemyCtrl EnemyCtrl => this.enemyCtrl;
        
        [SerializeField] protected CharacterState lastState = CharacterState.Ready;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.character.SetDirection(Vector2.left);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCharacter4D();
            this.LoadEnemyCtrl();
        }
        
        protected virtual void LoadCharacter4D()
        {
            if (this.character != null) return;
            this.character = this.GetComponentInChildren<Character4D>();
            Debug.Log(transform.name + ": LoadCharacter4D", gameObject);
        }

        protected virtual void LoadEnemyCtrl()
        {
            if(this.enemyCtrl != null) return;
            this.enemyCtrl = transform.GetComponent<EnemyCtrl>();
            Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject); 
        }

        public virtual void SetEnemyState(CharacterState state)
        {
            if (this.lastState == state) return;
            this.lastState = state;
            this.character.AnimationManager.SetState(state);
        }
    }
}
