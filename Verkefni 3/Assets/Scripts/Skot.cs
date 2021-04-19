using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skot : MonoBehaviour
{
    // ScoreM = Score Manager
    GameObject scoreM;
    Score_Manager A;
    private void Start()
    {
        scoreM = GameObject.Find("Score Holder");
        A = scoreM.GetComponent<Score_Manager>();
    }
    // þetta er keyrt þegar skotið snertir einhvað
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            try
            {
                A.Up_Score(5);
                Destroy(collision.gameObject);
            }
            catch { }
        }
    }
}
