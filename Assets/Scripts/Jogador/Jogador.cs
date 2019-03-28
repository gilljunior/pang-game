using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    [SerializeField]
    private Projetil _projetilInicial;
    public Arma arma;
       
    // Start is called before the first frame update
    void Start()
    {
        arma = new Arma(_projetilInicial, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) arma.Atirar(transform.position.x, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Drop"))
        {            
            arma.Projetil = col.gameObject.GetComponent<Drop>().SortearProjetil();
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
