using System.Collections;
using System.Collections.Generic;
using UnityEngine;

﻿public class FoxControler : MonoBehaviour
{
    // breitur
    public float speed = 3.0f;
    // stig
    int stig;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        // teingjast við Rigidbody2d
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // fá Player Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        /* ef að bæði Inputinn eru ekki ≈ 0
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        // segja animator hvað er að gerast
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        */
    }

    void FixedUpdate()
    {
        // fá staðsetningu
        Vector2 position = rigidbody2d.position;
        // bæta við þeiri hreifingu sem var feingin frá Input
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        // færa leikman
        rigidbody2d.MovePosition(position);
    }

    public void Stiga_breiting(int breiting)
    {
        stig += breiting;
        Debug.Log(stig);
    }
}
