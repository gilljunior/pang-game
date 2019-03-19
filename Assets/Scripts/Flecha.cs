using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float alcance = 3;
    public float velocidade = 0.1f;

    private float startPosY;
     
    private float heightCamera;

    public GameObject Inimigo;

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);

            Instantiate(Inimigo, new Vector2(-5, 2), Quaternion.identity);

        }
    }
}
