using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Folow : MonoBehaviour
{
    // beita Fyrir leiman svo óvinur viti hvern á að elta
    Transform Player;
    float speed = 0.052f;
    // það sem Y ásin fyrir rotation þar að vera styltur á til að óvinur snýr að leikmani
    float rotation;
    // leingdin á X ás að leikmanni
    float x;
    // leingdin á Z ás að leikmanni
    float z;
    void Start()
    {
        // Fina Game object með nafnið ↓ og taka transform frá því til að vinna með
        Player = GameObject.Find("FPSController").GetComponent<Transform>();
    }

    // fall til að finna út í hvaða átt leikmaður er
    void find_player()
    {
        // x,z er vigur í áttina að leikmanni
        x = Player.transform.position.x - transform.position.x;
        z = Player.transform.position.z - transform.position.z;
        //Debug.Log(x);
        //Debug.Log(z);
        // finna gráðurnar fyrir vigurinn 
        rotation = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
        //Debug.Log(rotation);
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
    float Detection_range(){
        float r = Mathf.Sqrt(x * x + z * z);
        return r;
}
    // Update er kallað 60 sinnum á sec
    void FixedUpdate()
    {
        find_player();
        // detection range til að það er ekki altaf verið að elta leikman
        if (Detection_range() <= 100)
        {
            transform.position += transform.forward * speed;
        }
    }
}
