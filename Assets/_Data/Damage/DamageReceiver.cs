using _Data.CommonScripts;
using UnityEngine;

public class DamageReceiver : SinhMonoBehaviour
{
    [SerializeField] protected int maxHp = 10;
    public int MaxHp => maxHp;
    [SerializeField] protected int currentHp = 10;
    public int CurrentHp => currentHp;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    protected override void OnEnable()
    {
        this.OnReborn();
    }
    
    public virtual int Deduct(int damage)
    {
        if(!this.isImmotal) this.currentHp -= damage;
        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
        if (this.currentHp < 0) this.currentHp = 0;
        return currentHp;
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHp <= 0;
    }

    protected virtual void OnDead()
    {
        //for override
    }
    
    protected virtual void OnHurt()
    {
        //for override
    }

    protected virtual void OnReborn()
    {
        this.currentHp = maxHp;
    }
}