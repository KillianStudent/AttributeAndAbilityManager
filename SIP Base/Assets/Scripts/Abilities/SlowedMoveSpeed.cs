using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Move Speed Slow (80%)")]
public class SlowedMoveSpeed : Ability
{
    public override void Initialize(GameObject obj)
    {
        obj.GetComponent<Movement>().MoveSpeed = obj.GetComponent<Movement>().MoveSpeed * 0.8f;
    }

    public override void TriggerAbility()
    {

    }
}
