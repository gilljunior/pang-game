using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projetil : MonoBehaviour
{
    public float velocidade;
    private float heightCamera;

    // Start is called before the first frame update
    void Start()
    {
        heightCamera = Camera.main.orthographicSize;
    }

    void Update()
    {
        if (transform.position.y >= heightCamera)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + velocidade);

    }
}
