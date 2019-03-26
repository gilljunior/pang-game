using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drop : MonoBehaviour
{

    public BoxCollider2D collider;
    public BoxCollider2D InimigoCollider;

    public List<Projetil> projeteisPossiveis;

    public Projetil projetilSorteado;


    // Start is called before the first frame update
    void Start()
    {

        System.Random rd = new System.Random();
        projetilSorteado = projeteisPossiveis[rd.Next(0, projeteisPossiveis.Count )];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
