using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // mesta l�f sem leikma�ur getur hafi�
    public int maxHealth = 5;
    // n�verandi l�f leikmans
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
        // teingast vi� rigid body
        rigidbody2d = GetComponent<Rigidbody2D>();
        // l�ta leikman byrja me� max health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // taka vi� input
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

        // me� �essur getur l�fi� ekki fari� yfir e�a undir min, max
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}