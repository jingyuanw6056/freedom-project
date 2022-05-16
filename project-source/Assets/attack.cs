using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator shine;

    private float attackCooldown = 2.0f;
    private float attackTracker = 0.0f;

    private float animCooldown = 0.3f;
    private float animTracker = 0.0f;

    public float range;
    public int damage = 1; 

    public Transform attackPos;
    public LayerMask enemy;

    // Update is called once per frame

    private void start ()
    {
        shine = GetComponent<Animator>();
    }

    void Update()
    {
        attackTracker += Time.deltaTime;
        animTracker += Time.deltaTime;

        if (attackTracker > attackCooldown)
        {
            if (Input.GetKeyDown("f"))
            {
                Debug.Log("BOnk");
                Collider2D[] ToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, enemy);
                for (int i = 0; i < ToDamage.Length; i++)
                {
                    ToDamage[i].GetComponent<slime>().health -= damage;
                }
                attackTracker = 0.0f;
                animTracker = 0.0f;
            }
        }

        if (animTracker < animCooldown)
        {
            shine.SetBool("smash", true);
        }
        else
        {
            shine.SetBool("smash", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }
}