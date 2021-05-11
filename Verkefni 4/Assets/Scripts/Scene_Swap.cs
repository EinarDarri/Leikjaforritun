using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Swap : MonoBehaviour
{
    // hvaða sean á að breita í
    public int sean;
    // Fyrir takka
    public void Byrja()
    {
        SceneManager.LoadScene(sean);
    }
    public void End()
    {
        Application.Quit();
    }
}
