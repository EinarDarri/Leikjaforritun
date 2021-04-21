using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Swap : MonoBehaviour
{
    //player game obj til að einduræsa stig
    public GameObject Player = null;
    // hvaða sean á að breita í
    public int sean;
    // Fyrir takka
    public void Byrja()
    {
        // ef að það er teingdur score Manager
        if (Player != null)
        {
            // þá skal enduræsa Score Manager
            Player.GetComponent<Score_Manager>().ResetScore();
        }
        SceneManager.LoadScene(sean);
    }
}
