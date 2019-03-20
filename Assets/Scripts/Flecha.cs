using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float alcance = 3;
    public float velocidade = 0.1f;
    private float startPosY;     
    private float heightCamera;
    public GameObject corda;
    public GameObject Inimigo;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        heightCamera = Camera.main.orthographicSize;

        corda = Instantiate(corda, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y >= heightCamera)
        {
            Destroy(gameObject);
            Destroy(corda);

        }

        corda.transform.localScale = new Vector2(corda.transform.localScale.x, transform.position.y - startPosY);
        float distanciaPercorrida = transform.position.y - startPosY;
        corda.transform.position = new Vector2(corda.transform.position.x, startPosY + (distanciaPercorrida / 2));
        transform.position = new Vector2(transform.position.x, transform.position.y + velocidade); 

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            Destroy(corda);
            // Instantiate(Inimigo, new Vector2(-5, 2), Quaternion.identity);
        }
    }
}
