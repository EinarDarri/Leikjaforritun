using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    //breita sem geimir Stig leikmans
    static int stig = 0;
    // breita sem beimir líf leikmans
    public static int Lif = 5;

    // text obj sem sýnir stig leikmans Dis_Stig => Display Stig
    public Text Dis_Stig;

    // text obj sem sýnir líf leikmans Dis_lif => Display Líf
    public Text Dis_lif;

    // fall til að hækka stig
    public void Up_Score(int Stiga_Haekkun)
    {
        stig+=Stiga_Haekkun;
    }
    // fall sem breitir fjölda lífa í ♥
    string lif_to_text()
    {
        string text = "";
        // fyrir fjölda ífa
        for (int x = 0; x <= Lif; x++)
        {
            // bæta ♥ í textan
            text += "♥ ";
        }
        // skila textanum
        return text;
    }

    // fall til að uppfæra UI Texta
    void Display_text()
    {
        // Uppfæra stiga textan
        Dis_Stig.text = "Stig : " + stig.ToString();
        // uppfæra líf textan
        Dis_lif.text = "Líf : " + lif_to_text();
    }

    void FixedUpdate()
    {
        Display_text();
    }
}
