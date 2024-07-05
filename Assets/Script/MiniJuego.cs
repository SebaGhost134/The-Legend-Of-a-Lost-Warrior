using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJuego : MonoBehaviour
{
     public string sceneName;
    // El nombre de la escena a cargar

    // Método que se llama cuando el collider del personaje entra en el trigger del objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Desactiva este GameObject (opcional)
            gameObject.SetActive(false);
            // Carga la escena especificada por sceneName
            SceneManager.LoadScene(sceneName);
        }
    }
}
