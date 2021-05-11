using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // breita fyrir rigidbody
    Rigidbody2D rigidbody2d;

    // �egar �essi ver�ur til
    void Awake()
    {
        // teinging til rigidbody2D
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // fall til a� henda
    public void Launch(Vector2 direction, float force)
    {
        // henda � �tt me� krafti
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        // ef a� �etta hefur fari� l�ngt � burtu
        if (transform.position.magnitude > 1000.0f)
        {
            // ey�a skotinu
            Destroy(gameObject);
        }
    }
    // �egar skotil snertir eitthva�
    void OnCollisionEnter2D(Collision2D other)
    {
        // reyna a� teingjast vi� enemy Controler
        EnemyController e = other.collider.GetComponent<EnemyController>();
        // ef a� �etta n�r a� teingjast vi� �vin
        if (e != null)
        {
            // laga �vinnin
            e.Fix();
        }
        // ey�a skotinu
        Destroy(gameObject);
    }
}