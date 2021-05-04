using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast vi� Player Colntoler Scripti�
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef a� �etta n�r teingingu vi� player controler script
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
