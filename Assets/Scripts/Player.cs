using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity = 0.1f;
    public float jumbForce = 17f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - velocity, transform.position.y);
    }
    
    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumbForce), ForceMode2D.Impulse);
    }


}
