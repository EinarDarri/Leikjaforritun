using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skot : MonoBehaviour
{
    // ScoreM = Score Manager
    GameObject scoreM;
    Score_Manager Score;
    private void Start()
    {
        // teingjast við Score Manager
        scoreM = GameObject.Find("Score Holder");
        Score = scoreM.GetComponent<Score_Manager>();
    }
    // þetta er keyrt þegar skotið snertir einhvað
    private void OnCollisionEnter(Collision collision)
    {
        // ef að skotið leindir á óvini
        if (collision.collider.tag == "Enemy")
        {
            try
            {
                // hæka stig leikmans um 5
                Score.Up_Score(5);
                // eyða óvini
                Destroy(collision.gameObject);
            }
            catch { }
        }
    }
}
