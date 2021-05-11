using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // hj�� sem ver�ur spila� �egar leikma�ur n�r �essum hlut
    public AudioClip collectedClip;

    // �egar eitthva� snertir �enan object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast vi� Player Colntoler Scripti�
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef a� �etta n�r teingingu vi� player controler script
        if (Controler != null)
        {
            // ef a� leikma�ur getur feingi� meira l�f
            if (Controler.health < Controler.maxHealth)
            {
                // h�ka l�f leikmans um 1
                Controler.ChangeHealth(1);
                // ey�a �essu helth collectibe
                Destroy(gameObject);
                // spila hj��
                Controler.PlaySound(collectedClip);
            }
        }
    }
}
