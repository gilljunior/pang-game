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

    private void FixedUpdate()
    {
        LimitarVelVertical();
        LimitarVelHorizontal();
    }

    private int auxVel;
    private float velocidadeAcumulada;

    private void LimitarVelVertical()
    {
        velocidadeAcumulada += Mathf.Abs(rB.velocity.y);
        if (auxVel++ >= 30)
        {
            var velocidadeMedia = velocidadeAcumulada / auxVel;

            if (velocidadeMedia < 2)
            {
                // Se a bolha estiver subindo
                if (rB.velocity.y > 0)
                {
                    // rB.velocity = new Vector2(rB.velocity.x, .2f);
                    rB.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
                }
                // Se a bolha estiver descendo
                else if (rB.velocity.y < 0)
                {
                    rB.AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
                }
            }
            velocidadeAcumulada = 0;
            auxVel = 0;
        }
    }

    private void LimitarVelHorizontal()
    {
        if (Mathf.Abs(rB.velocity.x) > 6)
        {
            // Se a bolha estiver indo para a direita
            if (rB.velocity.x > 0)
            {
                rB.AddForce(new Vector2(-20, 0), ForceMode2D.Force);
            }
            // Se a bolha estiver indo para a esquerda
            else if (rB.velocity.x < 0)
            {
                rB.AddForce(new Vector2(20, 0), ForceMode2D.Force);
            }
        }
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
