using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    private Rigidbody2D jump;
    private float jumpCooldown = 4.0f;
    private float jumpTracker = 0.0f;
    private float unCooldown = 10.0f;
    private float unTracker = 0.0f;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        jumpTracker += Time.deltaTime;
        unTracker += Time.deltaTime;

        if (jumpTracker > jumpCooldown)
        {
            jump.velocity = new Vector2(jump.velocity.x, 7.0f);
            jump.velocity = new Vector2(-5.0f, jump.velocity.y);
            if (unTracker > unCooldown) 
            {
                jump.velocity = new Vector2(-5.0f, jump.velocity.y);
                unTracker = 0.0f;
            }
            jumpTracker = 0.0f;
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }


}
