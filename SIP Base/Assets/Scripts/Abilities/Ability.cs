using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string AbilityName = "New Ability";
    public Sprite abilitySprite;
    public AudioClip abilitySound;
    public float aBaseCoolDown = 1f;
    public float StartTime = 0.1f;
    public float SpeedWeight = 0;
    public float PowerWeight = 0;
    public float TechWeight = 0;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
