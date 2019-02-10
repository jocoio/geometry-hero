﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Jumping & Grounded variables
  [HideInInspector] public bool jump = true;
  public Transform groundCheck;
  private bool grounded = false;
  public float jumpForce = 1000f;
  public float speed = 5f;

  private Vector2 speedVector;


  //private Animator anim;
  private Rigidbody2D rb2d;

  void Awake()
  {
    //anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
  }

  void Start()
  {
    speedVector = new Vector2(speed, rb2d.velocity.y);

  }

  void FixedUpdate()
  {
    if (jump)
    {
      rb2d.AddForce(new Vector2(0f, jumpForce));
      jump = false;
    }

    // If we start going to fast 
    if (Mathf.Abs(rb2d.velocity.x) > speed)
    {
      rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * speed, rb2d.velocity.y);
    }
    else
    {
      rb2d.AddForce(Vector2.right * speed);
    }
  }

  void Update()
  {
    grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

    if (Input.GetButtonDown("Jump") && grounded)
    {
      jump = true;
    }
  }
}