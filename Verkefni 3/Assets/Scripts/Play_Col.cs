using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Col : MonoBehaviour
{
    // breita sem teingist game objectinu sem er með score maneger scriptið (Score Holder)
    GameObject Score_Man;
    // breita sem teingist við score_Manager script
    Score_Manager Score_M;
    // breita fyrir síasta skráða y hnit
    float y;
    void Start()
    {
        // finna game objectið sem managar Score
        Score_Man = GameObject.Find("Score Holder");
        // teingjast við score Manager
        Score_M = Score_Man.GetComponent<Score_Manager>();
        detta();
    }
    // fall til að sjá um að drepa leikman ef hann dettur frá háum stað
    void detta()
    {
        // finna út hversu lángt leikmaður datt
        float tala = y - transform.position.y;
        // ef hann datt meira en 20m þá skal drepa leikman
        if ( tala >= 20)
        {
            Score_M.astaeda_dauda("þú dast frá háum stað");
        }
        // gera tilbúið að gá afur hvort að leikmaður hafi dottið
        y = transform.position.y;
        // keyra fall aftur eftir 1 sec
        Invoke("detta", 1);
    }
    void FixedUpdate()
    {
        // gá hvort að leikamður datt af heiminum
        if (transform.position.y <= -3)
        {
            Score_M.astaeda_dauda("þú dast af heiminum");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // ef að leikmaður snertir óvin 
        if (collision.collider.tag == "Enemy")
        {
            int loss = collision.collider.gameObject.GetComponent<Enemy>().life_taker;
            // láta leikman missa líf
            Score_M.Life_loss(loss);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // ef að leikmaður snertir vatn þá skal drepa hann
        if (other.tag == "Water")
        {
            Score_M.astaeda_dauda("þú Druknapir");
        }
    }
}
