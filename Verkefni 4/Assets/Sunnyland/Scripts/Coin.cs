using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // hversu m�rg stig �essi kr�na gefur
    public int points = 5;
    // teingast vi� script
    GameControler Master;

    void Start()
    {
        Master = GameObject.Find("GameManager").GetComponent<GameControler>();
        // H�ka max score
        Master.upScore(points);
        
    }
    // �egar eithva� snertir kr�nuna
    void OnTriggerEnter2D(Collider2D collision)
    {
        // teingjast vi� player script
        FoxControler Fox = collision.GetComponent<FoxControler>();

        // ef a� �a� n�r a� teingjast
        if (Fox != null)
        {
            // h�kka stig leikmans um points
            Fox.Stiga_breiting(points);
            // ey�a kr�nuni
            Destroy(this.gameObject);
        }
    }
}
