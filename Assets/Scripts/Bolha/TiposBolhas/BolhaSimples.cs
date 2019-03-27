
using UnityEngine;
public class BolhaSimples : Bolha
{
    public GameObject drop;

    void Awake()
    {
        aoSerAcertada.Add(new SubdividirAoSerAcertada(this, 2, 1));
        aoSerAcertada.Add(new DroparItem(this, drop, 5));
    }
}
