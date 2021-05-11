using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // breitur fyrir óvininn
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    AudioSource Hljod;

    // Start is called before the first frame update
    void Start()
    {
        // teingjast við rigidbody2D
        rigidbody2D = GetComponent<Rigidbody2D>();
        // setja upp timer
        timer = changeTime;
        // teingjast við Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ef að það er ekki búið að laga vélmenið
        if (!broken)
        {
            return;
        }
        // telja niður
        timer -= Time.deltaTime;
        // þegar það er búið að telja niður
        if (timer < 0)
        {
            // breta um átt
            direction = -direction;
            // byrja að telja aftur
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        // ef að það er ekki búið að laga vélmenið
        if (!broken)
        {
            return;
        }
        // gera vig sem vélmeni mun færa sig í
        Vector2 position = rigidbody2D.position;
        // ef vélmenið á að fara upp
        if (vertical)
        {
            // settja in þá átt sem á að hreifa sig í
            position.y = position.y + Time.deltaTime * speed * direction;
            // láta Animator vita hvernig vélmeni er að hreifa sig
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        // ef vélmenið er að fara til hliðar
        else
        {
            // settja in þá átt sem á að hreifa sig í
            position.x = position.x + Time.deltaTime * speed * direction;
            //  láta Animator vita hvernig vélmeni er að hreifa sig
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        // færa sig í þá att sem vigurinn segir
        rigidbody2D.MovePosition(position);
    }
    // ef að eithvað rekst á vélmenið
    void OnCollisionEnter2D(Collision2D other)
    {   
        // reina að teingjast við playerControler (Ruby)
        PlayerControler player = other.gameObject.GetComponent<PlayerControler>();
        // ef að það tókst að teingjast við leikman
        if (player != null)
        {
            // láta leikman missa líf
            player.ChangeHealth(-1);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    // fall til að kalla á til að laga vélmenið
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        //sína animation fyrir lagað vélmeni
        animator.SetTrigger("Fixed");
        // hætta með reykinn
        smokeEffect.Stop();
        // stoppa með hljóðið
        Hljod.Stop();
    }
}