using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma
{
    private Projetil _projetil;
    public Projetil Projetil {
        get
        {
            return _projetil;
        }
        set
        {
            _taxaDeTiro = (_taxaDeTiroBase + value.taxaDeTiro) / 2;
            _projetil = value;
        }
    }

    private readonly float _taxaDeTiroBase;
    private float _taxaDeTiro;
    // Armazena quando poderá ser dado o próximo tiro
    private float _proximoTiro;

    public Arma(Projetil projetilInicial, float taxaDeTiro)
    {
        _taxaDeTiroBase = taxaDeTiro;

        Projetil = projetilInicial;
    }

    public void Atirar(float x, float y)
    {
        if (Time.time <= _proximoTiro)
            return;

        _proximoTiro = Time.time + _taxaDeTiro;

        Object.Instantiate(Projetil, 
                            new Vector2(x, y), 
                            Quaternion.identity);
    }
}
