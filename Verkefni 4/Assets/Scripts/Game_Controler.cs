using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controler : MonoBehaviour
{
    // breita fyrir fj�lda �vina
    public int ovinir;
    // breita fyrir Ruby
    PlayerControler Ruby;
    void Start()
    {
        // teingjast vi� ruby
        Ruby = GameObject.Find("ruby").GetComponent<PlayerControler>();
    }

    void Update()
    {
        // ef a� Ruby missir allt l�fi� hj� s�r
        if (Ruby.health <= 0)
        {
            SceneManager.LoadScene(3);
        }
        if (ovinir <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
