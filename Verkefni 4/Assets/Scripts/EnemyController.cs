using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // breitur fyrir �vininn
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
        // teingjast vi� rigidbody2D
        rigidbody2D = GetComponent<Rigidbody2D>();
        // setja upp timer
        timer = changeTime;
        // teingjast vi� Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ef a� �a� er ekki b�i� a� laga v�lmeni�
        if (!broken)
        {
            return;
        }
        // telja ni�ur
        timer -= Time.deltaTime;
        // �egar �a� er b�i� a� telja ni�ur
        if (timer < 0)
        {
            // breta um �tt
            direction = -direction;
            // byrja a� telja aftur
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        // ef a� �a� er ekki b�i� a� laga v�lmeni�
        if (!broken)
        {
            return;
        }
        // gera vig sem v�lmeni mun f�ra sig �
        Vector2 position = rigidbody2D.position;
        // ef v�lmeni� � a� fara upp
        if (vertical)
        {
            // settja in �� �tt sem � a� hreifa sig �
            position.y = position.y + Time.deltaTime * speed * direction;
            // l�ta Animator vita hvernig v�lmeni er a� hreifa sig
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        // ef v�lmeni� er a� fara til hli�ar
        else
        {
            // settja in �� �tt sem � a� hreifa sig �
            position.x = position.x + Time.deltaTime * speed * direction;
            //  l�ta Animator vita hvernig v�lmeni er a� hreifa sig
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        // f�ra sig � �� att sem vigurinn segir
        rigidbody2D.MovePosition(position);
    }
    // ef a� eithva� rekst � v�lmeni�
    void OnCollisionEnter2D(Collision2D other)
    {   
        // reina a� teingjast vi� playerControler (Ruby)
        PlayerControler player = other.gameObject.GetComponent<PlayerControler>();
        // ef a� �a� t�kst a� teingjast vi� leikman
        if (player != null)
        {
            // l�ta leikman missa l�f
            player.ChangeHealth(-1);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    // fall til a� kalla � til a� laga v�lmeni�
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        //s�na animation fyrir laga� v�lmeni
        animator.SetTrigger("Fixed");
        // h�tta me� reykinn
        smokeEffect.Stop();
        // stoppa me� hlj��i�
        Hljod.Stop();
    }
}