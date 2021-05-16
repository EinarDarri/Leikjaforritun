using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    // hra�i
    public float speed = 3;
    // �tt
    public int direction = -1;
    // tenging fyrir rigidbody
    Rigidbody2D Rigidbody2d;
    // teinging fyrir Animator
    Animator animator;
    void Start()
    {
        // teingjast vi� rigid body
        Rigidbody2d = GetComponent<Rigidbody2D>();
        // teingjast vi� animator
        animator = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        // ef a� �etta hefur fari� l�ngt � burtu
        if (transform.position.magnitude > 100.0f)
        {
            // ey�a �vininum
            Destroy(gameObject);
        }
        if (Mathf.Approximately(Rigidbody2d.velocity.x, 0.0f)){
            direction = direction * -1;
        }

        // hreyfast
            Rigidbody2d.velocity = new Vector2(speed * direction, Rigidbody2d.velocity.y);
        // seygja animator hva� er a� gerast
        animator.SetFloat("Walk", direction);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // reyna a� teingjast vi� fox controler
        FoxControler Fox = collision.collider.GetComponent<FoxControler>();

        //ef a� �etta teingist vi� leikman
        if (Fox != null)
        {
            // l�ta leikmann missa sitg
            Fox.Stiga_breiting(-3);
        }
    }
    // ef eitthva� lendir ofan � �vininum
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ey�a �vininum
        Destroy(gameObject);
    }
}
