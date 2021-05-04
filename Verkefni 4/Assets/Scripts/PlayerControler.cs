using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // mesta líf sem leikmaður getur hafið
    public int maxHealth = 5;
    // núverandi líf leikmans
    public int currentHealth;
    // health property
    public int health { get { return currentHealth; } }
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // teingast við rigid body
        rigidbody2d = GetComponent<Rigidbody2D>();
        // láta leikman byrja með max health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // taka við input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        // með þessur getur lífið ekki farið yfir eða undir min, max
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}