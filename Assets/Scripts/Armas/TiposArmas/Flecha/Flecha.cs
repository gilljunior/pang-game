using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float velocidade = 0.1f;
    private float startPosY;
    private float heightCamera;
    public GameObject corda;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        heightCamera = Camera.main.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y >= heightCamera)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + velocidade);
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            Destroy(corda);
        }
    }
    
}
