using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Prefab fyrir Skot
    public GameObject Bullet;
    // breita fyrir hraða á Skoti
    public float Skot_Hradi = 0;

    void FixedUpdate()
    {
     if (Input.GetMouseButtonDown(0)){
            // gera nýjan game object sem er skot
            GameObject Skot = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
            // ná í rigidbody hjá skoti
            Rigidbody Skot_Rigidbody = Skot.GetComponent<Rigidbody>();
            // Henda skotinu áfram
            Skot_Rigidbody.AddForce(transform.forward * Skot_Hradi);
            // eyða skotinu eftir 3 sec til að filla ekki upp leikinn
            Destroy(Skot, 3f);
        }   
    }
}
