using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // breita fyrir rigidbody
    Rigidbody2D rigidbody2d;

    // þegar þessi verður til
    void Awake()
    {
        // teinging til rigidbody2D
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // fall til að henda
    public void Launch(Vector2 direction, float force)
    {
        // henda í átt með krafti
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        // ef að þetta hefur farið lángt í burtu
        if (transform.position.magnitude > 1000.0f)
        {
            // eyða skotinu
            Destroy(gameObject);
        }
    }
    // þegar skotil snertir eitthvað
    void OnCollisionEnter2D(Collision2D other)
    {
        // reyna að teingjast við enemy Controler
        EnemyController e = other.collider.GetComponent<EnemyController>();
        // ef að þetta nær að teingjast við óvin
        if (e != null)
        {
            // laga óvinnin
            e.Fix();
        }
        // eyða skotinu
        Destroy(gameObject);
    }
}