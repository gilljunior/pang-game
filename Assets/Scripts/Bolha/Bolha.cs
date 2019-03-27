using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour
{
    [Header("Propriedades Gerais")]
    [Tooltip("Tamanho inicial da bolha")]
    public int tamanho;
    [Tooltip("Valores positivos empurrarão a bolha para a direita, negativos para a esquerda")]
    public float forcaHorInicial;
    [Tooltip("Valores positivos empurrarão a bolha para a cima, negativos para a baixo")]
    public float forcaVerInicial;

    [Header("Componentes")]
    public Rigidbody2D rB;
    public CircleCollider2D cC;

    // Comportamento da bolha ao ser acertada
    protected List<IAoSerAcertada> aoSerAcertada = new List<IAoSerAcertada>();

    private void Start()
    {
        transform.localScale = new Vector2(tamanho, tamanho);
        rB.AddForce(new Vector2(forcaHorInicial, forcaVerInicial), ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arma"))
        {
            foreach (var comportamento in aoSerAcertada)
            {
                comportamento.Executar();
            }
        }
    }
}
