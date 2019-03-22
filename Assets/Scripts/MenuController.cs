using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void NovoJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void Fase1()
    {
        SceneManager.LoadScene(2);
    }
}
