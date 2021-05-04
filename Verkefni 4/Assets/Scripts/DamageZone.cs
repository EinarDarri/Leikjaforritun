using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // teingjast vi� Player Colntoler Scripti�
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef a� �etta n�r teingingu vi� player controler script
        if (Controler != null)
        {
            Controler.ChangeHealth(-1);
        }
    }
}
