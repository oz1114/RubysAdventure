using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;

    public float speed = 5.0f;
    public bool verticle;
    public float changeTime = 3.0f;

    float timer;
    int direction = 1;

    Rigidbody2D rigidbody2d;

    bool broken = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        move();
    }

    // move
    void move()
    {
        Vector2 position = rigidbody2d.position;
        if (verticle)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
            position.y = position.y + direction * speed * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
            position.x = position.x + direction * speed * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D character)
    {
        RubyController player = character.gameObject.GetComponent<RubyController>();

        if(player!=null && player.health > 0)
        {
            player.changeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
    }
}
