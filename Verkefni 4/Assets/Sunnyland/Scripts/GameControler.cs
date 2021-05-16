using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    // max score sem leikma�ur getur feingi�
    int maxScore;

    public FoxControler Fox;

    void FixedUpdate()
    {
        if (Fox.stig < 0)
        {
            SceneManager.LoadScene(3);
        }
        if (Fox.stig >= maxScore)
        {
            SceneManager.LoadScene(2);
        }
        if (Fox.transform.position.y <= -10)
        {
            SceneManager.LoadScene(3);
        }
    }
    // h�kka max 
    public void upScore(int score)
    {
        maxScore += score;
    }
}
