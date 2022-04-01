using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb2d;
    public float maxSpeed = 200f;
    public Animator animator;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        if(Input.GetKey("a") && GravitySwitch.Gravity == 1)
        {
            rb2d.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
            animator.SetFloat("Speed", 2f);
        }
        else if (Input.GetKey("d") && GravitySwitch.Gravity == 1)
        {
            rb2d.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
            animator.SetFloat("Speed", 2f);
        }
        else if (Input.GetKey("w") && GravitySwitch.Gravity == 2)
        {
            rb2d.AddForce(new Vector2(0, moveSpeed), ForceMode2D.Impulse);
            animator.SetFloat("Speed", 2f);
        }
        else if (Input.GetKey("s") && GravitySwitch.Gravity == 2)
        {
            rb2d.AddForce(new Vector2(0, -moveSpeed), ForceMode2D.Impulse);
            animator.SetFloat("Speed", 2f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    
        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }
}

