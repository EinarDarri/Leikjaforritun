using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    // hraði
    public float speed = 3;
    // átt
    public int direction = -1;
    // tenging fyrir rigidbody
    Rigidbody2D Rigidbody2d;
    // teinging fyrir Animator
    Animator animator;
    void Start()
    {
        // teingjast við rigid body
        Rigidbody2d = GetComponent<Rigidbody2D>();
        // teingjast við animator
        animator = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        // ef að þetta hefur farið lángt í burtu
        if (transform.position.magnitude > 100.0f)
        {
            // eyða óvininum
            Destroy(gameObject);
        }
        if (Mathf.Approximately(Rigidbody2d.velocity.x, 0.0f)){
            direction = direction * -1;
        }

        // hreyfast
            Rigidbody2d.velocity = new Vector2(speed * direction, Rigidbody2d.velocity.y);
        // seygja animator hvað er að gerast
        animator.SetFloat("Walk", direction);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // reyna að teingjast við fox controler
        FoxControler Fox = collision.collider.GetComponent<FoxControler>();

        //ef að þetta teingist við leikman
        if (Fox != null)
        {
            // láta leikmann missa sitg
            Fox.Stiga_breiting(-3);
        }
    }
    // ef eitthvað lendir ofan á óvininum
    void OnTriggerEnter2D(Collider2D collision)
    {
        // eyða óvininum
        Destroy(gameObject);
    }
}
