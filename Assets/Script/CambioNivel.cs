using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Cambio")
        {
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}
