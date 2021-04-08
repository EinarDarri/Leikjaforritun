using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Einar Darri
    // Breitur
    // Hversu Hratt leikmaður snýr sér
    public float snuningur = 1.5f;
    // Hversu Hratt fer leikmaður áfram
    public float Hradi = .2f;
    // hversu hátt hoppar leikmaður
    public float hop = 1;
    // Rigidbody
    private Rigidbody leikmadur;
    // Stigin sem leikmaður er með
    private static int Score = 0;
    // Textinn sem leikmaður sér (Text object)
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hallo - Einar Darri");
        leikmadur = GetComponent<Rigidbody>();
        SetScoreText();
    }

    // Fixed Update er kallað 60 sinum á sec
    void FixedUpdate()
    {
        // ef leikamður dettur enda leikinn
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(3);
        }
        // fara áfram ef það er ýtt á ↑ örrina
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Hradi;
        }
        // fara afturábak ef það er ýtt á ↓ örrina
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * Hradi;
        }
        // snúa leikmanni til Hægri ef það er ýtt á → Örrina
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, snuningur, 0);
        }
        // Snúa leikmanni til Vinstri ef það er ýtt á ← Örrina
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -snuningur, 0);
        }
        // Hoppa ???
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log(transform.position);
            transform.position += transform.up * hop;
        }
    }
    // Uppfæra textan sem byrtir stiginn
    void SetScoreText()
    {
        ScoreText.text = "Stig Þín eru : " + Score.ToString();
    }
    //enduræsa stig leikmans
    public void ResetScore()
    {
        Score = 0;
    }
    // þegar leikmaður rekst á einhvað
    private void OnCollisionEnter(Collision collision)
    {
        // ef að leikmaður rekst á krónu
        if (collision.collider.tag == "Coin")
        {
            // taka krónuna úr leik því keimaður er búinn að ná krónuni
            collision.collider.gameObject.SetActive(false);
            // hæka stinginn um 1
            Score++;
            //Debug.Log("Stiginn eru : " + Score);
            // uppfæra textan sem byrtir stinginn
            SetScoreText();
        }

        // ef leikmaður rekst á Hindrun
        if (collision.collider.tag == "Hindrun")
        {
            // læka stiginn um 1
            Score--;
            //Debug.Log("Stiginn eru : " + Score);
            // uppfæra textan sem byrtir stinginn
            SetScoreText();
        }
    }
}
