using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

﻿public class FoxControler : MonoBehaviour
{
    // breitur
    public float speed = 3.0f;
    public float JumpSpeed = 40f;
    // hreifing vertical
    float move_vertical { get {
            if (vertical <= 0)
            {
                return gravity;
            }
            else
            {
                return JumpSpeed;
            }
        } }
    // mitt þíngdar afl
    public float gravity = 5f;
    // stig
    int stig;
    // rigid body
    Rigidbody2D rigidbody2d;
    // input
    float horizontal;
    float vertical;

    // UI
    // score texti
    public Text Score_Text;

    // fyrir animations
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        // þýngdar afl fer niður
        gravity = gravity * -1;
        // teingjast við Rigidbody2d
        rigidbody2d = GetComponent<Rigidbody2D>();
        // teingjast við Animator
        animator = GetComponent<Animator>();
        // birta stig leikmans
        update_score_text();
    }

    // Update is called once per frame
    void Update()
    {
        // fá Player Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // ef að bæði Inputinn eru ekki ≈ 0
        if (!Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f))
        {
            lookDirection.Set(horizontal, vertical);
            lookDirection.Normalize();
        }
        // segja animator hvað er að gerast
        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        animator.SetFloat("Speed", new Vector2(horizontal, vertical).magnitude);
    }

    void FixedUpdate()
    {
        // hreifing
        rigidbody2d.velocity = new Vector2(speed * horizontal, move_vertical);
        
        
    }

    public void Stiga_breiting(int breiting)
    {
        stig += breiting;
        // birta stig leikmans
        update_score_text();
    }

    void update_score_text()
    {
        Score_Text.text = "Score : " + stig.ToString();
    }
}
