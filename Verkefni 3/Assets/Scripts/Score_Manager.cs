using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// script sem sér um öll gildi sem leikmaður er með
public class Score_Manager : MonoBehaviour
{
    //breita sem geimir Stig leikmans
    static int stig = 0;
    // breita sem beimir líf leikmans
    static int Lif = 5;
    // breita sem seigir til hvernig leikmaður dó
    static string Daudi;
    // text obj sem sýnir stig leikmans Dis_Stig => Display Stig
    public Text Dis_Stig;

    // text obj sem sýnir líf leikmans Dis_lif => Display Líf
    public Text Dis_lif;

    // text obj sem sýnir ástæðuna fyrir því að leikmaður dó;
    public Text Dis_Daud;

    private void Start()
    {
        // ef að það er ástæða fyrir því að leikmaður dó og að það er texta object til að birta það í þá skall sýna ástæðuna
        if (Daudi != null && Dis_Daud != null)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Dis_Daud.text = "Þú Dóst útaf " + Daudi;
        }
    }

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
        for (int x = 0; x < Lif; x++)
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
        // uppfæra stig textan ef það er gefi texta object til að gera það
        if (Dis_Stig != null)
        {
            // Uppfæra stiga textan
            Dis_Stig.text = "Stig : " + stig.ToString();
        }
        // uppfæra líf textan ef það er gefið texta object til að setja það í
        if (Dis_lif != null)
        {
            // uppfæra líf textan
            Dis_lif.text = "Líf : " + lif_to_text();
        }
    }
    // fall sem lætur leiman missa líf
    public void Life_loss() {
        // draga 1 frá lífi leikmans
        Lif--;
    }
    // fall sem vistar ástæðu dauða
    public void astaeda_dauda(string astaeda = null){
        // vista ástæðu dauða
        Daudi = astaeda;
        // fara á enda scene
        SceneManager.LoadScene(2);
        }
    // fall til að endur ræsta stig leikmans svo hægt sé að byrja upp á nýtt
    public void ResetScore()
    {
        // endur stilla allar breitur sem þarf (static)
        stig = 0;
        Lif = 5;
        Daudi = null;
    }
    void FixedUpdate()
    {
        Display_text();
        // ef að leikmaður klára líf sín þá skal drepa hann
        if (Lif <= 0)
        {
            Lif = 1;
            astaeda_dauda("þú Kláraðir líf þín");
        }
    }
}
