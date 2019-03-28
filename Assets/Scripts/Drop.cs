using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drop : MonoBehaviour
{

    public BoxCollider2D collider;
    public BoxCollider2D InimigoCollider;

    public List<Projetil> projeteisPossiveis;
    
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Projetil SortearProjetil()
    {
        System.Random rd = new System.Random();
        var nb = rd.Next(0, projeteisPossiveis.Count);
        return projeteisPossiveis[nb];
    }

}
