using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    public float velocidade = 0.1f;
    public float forcaPulo = 12f;
    public Rigidbody2D rb;

    public int qtdPulos = 2;
    private int puloAtual = 0;

    public Projetil projetilAtual;

    public List<Projetil> projeteisPossiveis;

    // Start is called before the first frame update
    void Start()
    {
        projetilAtual = projeteisPossiveis.FirstOrDefault(x => x.GetType() == typeof(Bala));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) MoverDireita();
        if (Input.GetKey(KeyCode.LeftArrow)) MoverEsquerda();   
        if (Input.GetKeyDown(KeyCode.UpArrow)) Pular();
        if (Input.GetKeyDown(KeyCode.Space)) Atirar();
    }

    public void MoverDireita()
    {
        transform.position = new Vector2(transform.position.x + velocidade, transform.position.y);
    }

    public void MoverEsquerda()
    {
        transform.position = new Vector2(transform.position.x - velocidade, transform.position.y);
    }
    
    public void Pular()
    {
        if(puloAtual < qtdPulos)
        {
            rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            puloAtual++;
        }

    }

    public void Atirar()
    {
        Instantiate(projetilAtual, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(0);
        }

        if (col.gameObject.CompareTag("Plataforma"))
        {
            puloAtual = 0;
        }
    }
}
