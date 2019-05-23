using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public LayerMask blockLayer;
    public float moveSpeed = 5f;
    Rigidbody2D rd2D;
    Collider2D c2D;

    Animator animator;
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
        c2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        int xDir = (int)Input.GetAxisRaw("Horizontal");
        int yDir = (int)Input.GetAxisRaw("Vertical");

        if (xDir != 0)
        {
            if(canMove)
                animator.SetBool("idle_direction", xDir > 0);
        }

        if (xDir != 0 || yDir != 0)
        {
            AttemptMove(xDir, yDir);
        }
    }


    private bool canMove = true;

    private void AttemptMove(int xDir, int yDir)
    {

        c2D.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(rd2D.position, new Vector2(xDir, yDir), 1f, blockLayer);
        Debug.Log($"hit:{hit.collider}");
        c2D.enabled = true;
        if (hit.collider == null)
        {
            if (canMove)
                StartCoroutine(SmoothMovement(rd2D.position + new Vector2(xDir, yDir)));
        }
        else
        {
            Debug.Log("碰到物体的名称:" + hit.transform.gameObject.tag);
        }
    }

    private IEnumerator SmoothMovement(Vector2 end)
    {
        canMove = false;
        float sqrRemainingDistance = (rd2D.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector2 newPos = Vector2.MoveTowards(rd2D.position, end, moveSpeed * Time.deltaTime);
            Debug.Log($"new pos :{newPos}");
            rd2D.MovePosition(newPos);
            sqrRemainingDistance = (rd2D.position - end).sqrMagnitude;
            yield return false;
        }
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("碰到物体的名称:" + collision.GetType().ToString());
    }

    public void Move(int xDir, int yDir)
    {
        rd2D.MovePosition(new Vector2(rd2D.position.x + xDir, rd2D.position.y + yDir));
    }
}
