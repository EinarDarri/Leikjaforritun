using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    // breitur
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    void Start()
    {
        // fela texta boxið
        dialogBox.SetActive(false);
        // setja tíman á það sem hann mundi vera ef boxið væri fallið
        timerDisplay = -1.0f;
    }

    void Update()
    {
        // ef að það er verið að sýna textan
        if (timerDisplay >= 0)
        {
            // telja niður tíman
            timerDisplay -= Time.deltaTime;
            // ef að tímin er kominn á 0
            if (timerDisplay < 0)
            {
                // fela texta boxið
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        // seta tíman á displayTime (breita fyrir hversu leingi textin verður uppu)
        timerDisplay = displayTime;
        // sýna textan
        dialogBox.SetActive(true);
    }
}
