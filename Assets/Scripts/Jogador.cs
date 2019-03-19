using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{

    public float velocidade = 0.1f;
    public float forcaPulo = 17f;
    public Rigidbody2D rb;

    public GameObject Flecha;

    // Start is called before the first frame update
    void Start()
    {
        
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
        rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
    }

    public void Atirar()
    {
        Instantiate(Flecha, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(0);
        }
    }


}
