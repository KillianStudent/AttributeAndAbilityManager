using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Driving Strike")]
public class DrivingStrike : Ability
{
    public float DashingTime = 0.25f;
    private GameObject _obj;

    bool Activate;

    public override void Initialize(GameObject obj)
    {
        _obj = obj;
    }

    public override void TriggerAbility()
    {
        _obj.GetComponent<Movement>().StartCoroutine(_DrivingStrike());
    }

    IEnumerator _DrivingStrike()
    {
        float timePassed = 0;
        float MoveX = _obj.GetComponent<Movement>().moveDirection.x;
        float MoveY = _obj.GetComponent<Movement>().moveDirection.y;
        _obj.GetComponent<Movement>().Actionable = false;
        while (timePassed < DashingTime)
        {
            timePassed += Time.deltaTime;
            _obj.GetComponent<Movement>().rb.velocity += new Vector2(MoveX * 2.5f, MoveY * 2.5f);
            yield return null;
        }
        _obj.GetComponent<Movement>().Actionable = true;
        _obj.GetComponent<Movement>().rb.velocity = new Vector2(0, 0);
    }
}