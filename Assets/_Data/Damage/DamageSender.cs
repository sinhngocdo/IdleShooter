using _Data.CommonScripts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DamageSender : SinhMonoBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected Rigidbody rigid;
    
    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter(Collider other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if(damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }
    
    protected virtual void LoadRigidbody()
    {
        if(this.rigid != null) return;
        this.rigid = this.GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + "LoadRigidbody", gameObject);
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    public virtual void SetDamage(int damage)
    {
        this.damage = damage;
    }
    

}