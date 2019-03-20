using UnityEngine;

public class Flecha : MonoBehaviour
{
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

        transform.position = new Vector2(transform.position.x, transform.position.y + velocidade);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            // Instantiate(Inimigo, new Vector2(-5, 2), Quaternion.identity);
        }
    }
}
