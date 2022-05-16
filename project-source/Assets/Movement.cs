using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D player;
    private float jumpCooldown = 2.0f;
    private float jumpTracker = 0.0f;
    private float iFrameCooldown = 2.0f;
    private float iFrameTracker = 0.0f;
    public int health = 100; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        jumpTracker += Time.deltaTime;
        iFrameTracker += Time.deltaTime;

        float dirX = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(dirX * 7.0f, player.velocity.y);

        if (jumpTracker > jumpCooldown)
        { 
            if (Input.GetButtonDown("Jump"))
            {
                player.velocity = new Vector2(player.velocity.x, 8);
                jumpTracker = 0;
            }
        }
    }
    
    private void  OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Slime")
        {
            if (iFrameTracker > iFrameCooldown) 
            {
                health -= 10;
                iFrameTracker = 0;
                Debug.Log(health);
            }
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
