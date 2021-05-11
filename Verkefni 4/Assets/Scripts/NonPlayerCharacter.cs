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
        // fela texta boxi�
        dialogBox.SetActive(false);
        // setja t�man � �a� sem hann mundi vera ef boxi� v�ri falli�
        timerDisplay = -1.0f;
    }

    void Update()
    {
        // ef a� �a� er veri� a� s�na textan
        if (timerDisplay >= 0)
        {
            // telja ni�ur t�man
            timerDisplay -= Time.deltaTime;
            // ef a� t�min er kominn � 0
            if (timerDisplay < 0)
            {
                // fela texta boxi�
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        // seta t�man � displayTime (breita fyrir hversu leingi textin ver�ur uppu)
        timerDisplay = displayTime;
        // s�na textan
        dialogBox.SetActive(true);
    }
}
