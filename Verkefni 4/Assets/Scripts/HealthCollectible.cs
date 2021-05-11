using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // hjóð sem verður spilað þegar leikmaður nær þessum hlut
    public AudioClip collectedClip;

    // þegar eitthvað snertir þenan object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast við Player Colntoler Scriptið
        PlayerControler Controler = collision.GetComponent<PlayerControler>();

        // ef að þetta nær teingingu við player controler script
        if (Controler != null)
        {
            // ef að leikmaður getur feingið meira líf
            if (Controler.health < Controler.maxHealth)
            {
                // hæka líf leikmans um 1
                Controler.ChangeHealth(1);
                // eyða þessu helth collectibe
                Destroy(gameObject);
                // spila hjóð
                Controler.PlaySound(collectedClip);
            }
        }
    }
}
