using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 3.0f;
    public int maxHealth = 5;
    public int health { get {return cHealth; } }
    int cHealth;

    public float invincibleTime = 2.0f;
    bool isInvincible = false;
    float invincibleTimer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        cHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        RubyMove();

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    //get input and move character
    void RubyMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    //change character's health
    public void changeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }
        cHealth = Mathf.Clamp(cHealth + amount, 0, maxHealth);
        Debug.Log(cHealth + "/" + maxHealth);
    }
}
