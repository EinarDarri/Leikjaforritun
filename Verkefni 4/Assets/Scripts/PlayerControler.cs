using System.Collections;
using System.Collections.Generic;
using UnityEngine;

﻿public class PlayerControler : MonoBehaviour
{
    // breitur
    public float speed = 3.0f;

    public int maxHealth = 5;

    public GameObject projectilePrefab;

    public AudioClip throwSound;
    public AudioClip hitSound;

    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // teingjast við Rigidbody2d
        rigidbody2d = GetComponent<Rigidbody2D>();
        // teingjast við Animator
        animator = GetComponent<Animator>();
        // setja current health sem maxhealth
        currentHealth = maxHealth;
        // teingjast við AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // fá Player Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // gera það að Vigri
        Vector2 move = new Vector2(horizontal, vertical);
        // ef að bæði Inputinn eru ekki ≈ 0
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        // segja animator hvað er að gerast
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        // ef að leikamður tók nýlega damage
        if (isInvincible)
        {
            // telja niður
            invincibleTimer -= Time.deltaTime;
            // þegar tímin er búinn
            if (invincibleTimer < 0)
                // leifa leikmani að missa líf aftur
                isInvincible = false;
        }
        // ef að það er ýtt á "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            // skjóta
            Launch();
        }
        // ef að það er ýtt á "X"
        if (Input.GetKeyDown(KeyCode.X))
        {
            // setna ýt Raycast
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            // ef að reycast hitti eithvað í NPC layer
            if (hit.collider != null)
            {
                // reyna að teingjast við NPC
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                // ef að það nær að teingjast
                if (character != null)
                {
                    // birta texta boxið
                    character.DisplayDialog();
                }
            }
        }
    }

    void FixedUpdate()
    {
        // fá staðsetningu
        Vector2 position = rigidbody2d.position;
        // bæta við þeiri hreifingu sem var feingin frá Input
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        // færa leikman
        rigidbody2d.MovePosition(position);
    }
    // fall til að breita lífi leikmans
    public void ChangeHealth(int amount)
    {   
        // ef að leikmaður er að fara að missa líf
        if (amount < 0)
        {
            // ef leikmaður er ekki búinn að missa líf nýlega
            if (isInvincible)
                return;
            // merka að leikmaður misti líf nýlega
            isInvincible = true;
            // stilla tímara
            invincibleTimer = timeInvincible;
            // spila animation fyrir að leikmaður misti líf
            animator.SetTrigger("Hit");
            // spila hljóð fyrir að leikmaður misti líf
            PlaySound(hitSound);
        }
        // uppfæra líf leikamns
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        // uppfæra health bar
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    // fall til að skjóta
    void Launch()
    {
        // gera projectile
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        // teingjast við script hjá því
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        // skjóta því áfram
        projectile.Launch(lookDirection, 300);
        // spila animation fyrir að það var skotið
        animator.SetTrigger("Launch");
        // spila hljóð fyrir að það var skotið
        PlaySound(throwSound);
    }
    // fall til að spila hljóð
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}