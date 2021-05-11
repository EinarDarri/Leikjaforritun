using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controler : MonoBehaviour
{
    // breita fyrir fjölda óvina
    public int ovinir;
    // breita fyrir Ruby
    PlayerControler Ruby;
    void Start()
    {
        // teingjast við ruby
        Ruby = GameObject.Find("ruby").GetComponent<PlayerControler>();
    }

    void Update()
    {
        // ef að Ruby missir allt lífið hjá sér
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
