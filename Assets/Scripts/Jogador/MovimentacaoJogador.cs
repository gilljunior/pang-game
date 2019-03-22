using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public float velocidade = 10f;

    public float forcaPulo = 12f;
    public int qtdPulos = 2;
    private int puloAtual = 0;

    bool viradoDireita = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Armazena input de movimentação horizontal
        float axis = (Input.GetAxis("Horizontal"));

        if (axis != 0)
        {
            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime * (axis * 100), transform.position.y);

            if ((axis > 0 && !viradoDireita) || (axis < 0 && viradoDireita))
                InverterSprite();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Pular();
    }

    private void Pular()
    {
        if (puloAtual < qtdPulos)
        {
            rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            puloAtual++;
        }
    }

    private void InverterSprite()
    {
        viradoDireita = !viradoDireita;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
            puloAtual = 0;
        }
    }
}
