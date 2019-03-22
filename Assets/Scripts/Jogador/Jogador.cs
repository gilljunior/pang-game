﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.Space)) Atirar();
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
    }
}
