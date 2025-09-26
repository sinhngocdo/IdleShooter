
using System;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] protected Character4D character;
    [SerializeField] protected AnimationManager anim;

    private float xMove, yMove;

    private void Start()
    {
        character.SetDirection(Vector2.right);
        anim.SetState(CharacterState.Idle);
    }
}
