using _Data.CommonScripts;
using UnityEngine;

namespace _Data.Player
{
    public abstract class PlayerAbstract : SinhMonoBehaviour
    {
        [Header("Player Abstract")]
        [SerializeField] protected PlayerCtrl playerCtrl;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPlayerCtrl();
        }

        protected virtual void LoadPlayerCtrl()
        {
            if(this.playerCtrl != null) return;
            this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
            Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject); 
        }
    }
}