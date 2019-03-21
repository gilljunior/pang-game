using UnityEngine;

public class Flecha : Projetil
{
    private float startPosY;


    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
    }
    
}
