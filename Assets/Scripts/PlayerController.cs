using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public LayerMask blockLayer;
    Rigidbody2D rigidbody2D;
    Collider2D collider2D;
    
    Animator animator;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int xDir = (int)Input.GetAxisRaw("Horizontal");
        int yDir = (int)Input.GetAxisRaw("Vertical");

        if (xDir != 0)
        {
            animator.SetBool("idle_direction", xDir > 0);
        }
            
        if (xDir != 0 || yDir != 0)
        {
            AttemptMove(xDir, yDir);
        }
    }


    private void AttemptMove(int xDir, int yDir)
    {
        
        collider2D.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position, new Vector2(xDir, yDir), 1f, blockLayer);
        Debug.Log($"hit:{hit.collider}");
        collider2D.enabled = true;
        if (hit.collider == null)
        {
            Move(xDir, yDir);
        }
        else
        {
            Debug.Log("碰到物体的名称:" + hit.transform.gameObject.tag);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("碰到物体的名称:" + collision.GetType().ToString());
    }

    public void Move(int xDir,int yDir)
    {
        rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x + xDir, rigidbody2D.position.y + yDir));
    }
}
