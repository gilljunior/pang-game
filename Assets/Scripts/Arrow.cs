using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float alcance = 3;
    public float speed = 0.05f;

    private float startPosY;

    private int UP = 0;
    private int DOWN = 1;

    private int direction;
        
    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        direction = UP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(startPosY);
        
        if(transform.position.y >= (startPosY + alcance))
        {
            direction = DOWN;
        }

        if(direction == UP)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }

        if(direction == DOWN && transform.position.y <= startPosY)
        {
            Destroy(gameObject);
        }


    }
}
