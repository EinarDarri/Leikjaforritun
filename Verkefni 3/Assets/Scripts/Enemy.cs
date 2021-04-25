using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // breita fyrir hversu mörg stig þessi óvinur gefur
    public int Stig = 5;
    // breita fyrir hversu mörg líf óvinur er með
    public int life = 1;
    // berta sem sínir hversu mörg líf óvinur tekur af leikmanni
    public int life_taker = 1;

    // ScoreM = Score Manager
    GameObject scoreM;
    Score_Manager Score;
    private void Start()
    {
        // teingjast við Score Manager
        scoreM = GameObject.Find("Score Holder");
        Score = scoreM.GetComponent<Score_Manager>();
    }
    // ef að óvinur er skotin kalla á þetta fall
    public void Hit()
    {
        // láta óvin  missa líf
        life--;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ef að líf hjá óvini eru 0 þá deyr hann
        if (life <= 0)
        {
            try
            {
                // hæka stig leikmans um stig
                Score.Up_Score(Stig);
                // eyða óvini
                Destroy(this.gameObject);
            }
            catch { }
        }
    }
}
