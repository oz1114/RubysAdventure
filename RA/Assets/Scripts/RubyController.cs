using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RubyMove();
    }

    //get input and move character
    void RubyMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;

        position.x = position.x + 15.0f * horizontal * Time.deltaTime;
        position.y = position.y + 15.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
