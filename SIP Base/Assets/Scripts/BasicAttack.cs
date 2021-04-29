using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public Collider2D hitbox;
    public float ActiveTime = 0.5f;

    void Start()
    {
        hitbox = GetComponent<CircleCollider2D>();
        hitbox.enabled = false;
    }

    IEnumerator attack()
    {
        float timePassed = 0;
        hitbox.enabled = true;
        while (timePassed < ActiveTime)
        {
            timePassed += Time.deltaTime;
            Debug.Log("sqee");
            yield return null;
        }
        hitbox.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(attack());
        }
    }
}
