using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Swap : MonoBehaviour
{
    // hvaða sean á að breita í
    public int sean;
    // þegar einhvað kemur við trigger
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Colision");
        // ef að Leikmaður kemur við trigger
        SceneManager.LoadScene(sean);
        Debug.Log("AAAA");
    }
    // Fyrir takka 
    public void Byrja()
    {
        SceneManager.LoadScene(sean);
    }
}
