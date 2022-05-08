using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    private float attackCooldown = 2.0f;
    private float attackTracker = 0.0f;

    public float range;
    public int damage = 1; 

    public Transform attackPos;
    public LayerMask enemy;

    // Update is called once per frame

    void Update()
    {
        attackTracker += Time.deltaTime;

        if (attackTracker > attackCooldown)
        {
            if (Input.GetKeyDown("f"))
            {
                Debug.Log("attacked");
                Collider2D[] ToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, enemy);
                for (int i = 0; i < ToDamage.Length; i++)
                {
                    ToDamage[i].GetComponent<slime>().health -= damage;
                }
                attackTracker = 0;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }
}