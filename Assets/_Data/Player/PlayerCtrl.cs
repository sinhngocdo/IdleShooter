using System.Linq;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Data;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class PlayerCtrl : SinhMonoBehaviour
{
    [SerializeField] protected Character4D character;


    // Start is called before the first frame update
    void Start()
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
}