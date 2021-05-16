using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

﻿public class FoxControler : MonoBehaviour
{
    // breitur
    public float speed = 3.0f;
    public float Jumpforce = 400f;
    // er leimaður að snerta jörð?
    public bool IsOnGroun;
    // stig
    public int stig;
    // rigid body
    Rigidbody2D rigidbody2d;
    // input
    float horizontal;
    float vertical;

    GameControler Master;

    // UI
    // score texti
    public Text Score_Text;

    // fyrir animations
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        // teingjast við Rigidbody2d
        rigidbody2d = GetComponent<Rigidbody2D>();
        // teingjast við Animator
        animator = GetComponent<Animator>();
        // birta stig leikmans
        update_score_text();
        // teingjast við GameContorler Script
        Master = GameObject.Find("GameManager").GetComponent<GameControler>();
    }

    // Update is called once per frame
    void Update()
    {
        // fá Player Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // ef að bæði Inputinn eru ekki ≈ 0
        if (!Mathf.Approximately(horizontal, 0.0f))
        {
            lookDirection.Set(horizontal, 0);
            lookDirection.Normalize();
        }
        // segja animator hvað er að gerast
        animator.SetFloat("MoveX", lookDirection.x);
        animator.SetFloat("MoveY", rigidbody2d.velocity.y);
        animator.SetFloat("Speed", new Vector2(horizontal, 0).magnitude);
    }

    void FixedUpdate()
    {
        // hreifing fyrir x ás
        // Debug.Log(rigidbody2d.velocity.y);
        rigidbody2d.velocity = new Vector2(speed * horizontal, rigidbody2d.velocity.y);
        if (IsOnGroun && vertical >= 0.4)
        {
            rigidbody2d.AddForce( new Vector2 (0, Jumpforce));
            animator.SetTrigger("Jump");
        }

        IsOnGroun = false;
        
        
    }

    public void Stiga_breiting(int breiting)
    {
        // ef að það er verið að lækka stig leikmans
        if (breiting < 0)
        {
            // lækka fjölda stiga sem hann þarf að fá til að vinna
            Master.upScore(breiting);
        }
        stig += breiting;
        // birta stig leikmans
        update_score_text();
    }

    void update_score_text()
    {
        Score_Text.text = "Score : " + stig.ToString();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Tilemap")
        {
            IsOnGroun = true;
        }
    }

}
