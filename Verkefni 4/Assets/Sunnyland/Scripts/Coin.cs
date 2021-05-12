using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // hversu mörg stig þessi króna gefur
    public int points = 5;
    
    // þegar eithvað snertir krónuna
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast við player script
        FoxControler Fox = collision.GetComponent<FoxControler>();

        // ef að það nær að teingjast
        if (Fox != null)
        {
            // hækka stig leikmans um points
            Fox.Stiga_breiting(points);
            // eyða krónuni
            Destroy(this.gameObject);
        }
    }
}
