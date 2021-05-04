using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // teingjast við Player Colntoler Scriptið
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef að þetta nær teingingu við player controler script
        if (Controler != null)
        {
            Controler.ChangeHealth(-1);
        }
    }
}
