﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(new BolhaSimples());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbrirMenu()
    {
        SceneManager.LoadScene(0);
    }
}
