using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast við Player Colntoler Scriptið
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef að þetta nær teingingu við player controler script
        if (Controler != null)
        {
            if (Controler.health < Controler.maxHealth)
            {
                Controler.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
