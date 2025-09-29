using System.Linq;
using _Data.CommonScripts;
using _Data.Object.Bullet;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Data;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class PlayerCtrl : SinhMonoBehaviour
{
    [SerializeField] protected Character4D character;
    
    [SerializeField] protected SpawnerBullet bulletSpawner;
    public SpawnerBullet BulletSpawner => this.bulletSpawner;
    
    protected string bulletName = "Bullet";
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => this.bullet;
    
    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => this.bulletPrefabs;


    // Start is called before the first frame update
    protected override void OnEnable()
    {
        this.character.SetDirection(Vector2.right);

        var itemGun = this.character.SpriteCollection.Firearm1H[1];
        this.EquipGun(itemGun, EquipmentPart.Firearm1H);
        
        this.character.AnimationManager.SetState(CharacterState.Ready);
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacter4D();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
    }

    protected virtual void LoadCharacter4D()
    {
        if (this.character != null) return;
        this.character = this.GetComponentInChildren<Character4D>();
        Debug.Log(transform.name + ": LoadCharacter4D", gameObject);
    }

    protected virtual void EquipGun(ItemSprite itemSprite, EquipmentPart typeGun)
    {
        this.character.Equip(itemSprite, typeGun);
    }
    
    protected virtual void LoadBulletSpawner()
    {
        if(this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectOfType<SpawnerBullet>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);       
    }
    
    protected virtual void LoadBullet()
    {
        if(this.bullet != null) return;
        this.bullet = this.BulletPrefabs.GetByName(this.bulletName);
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);       
    }
    
    protected virtual void LoadBulletPrefabs()
    {
        if(this.bulletPrefabs != null) return;
        this.bulletPrefabs = FindAnyObjectByType<BulletPrefabs>();
        Debug.LogWarning(transform.name + ": LoadBulletPrefabs", gameObject);
        this.LoadBullet();
    }
}