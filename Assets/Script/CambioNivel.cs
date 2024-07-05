using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que controla el cambio de nivel en el juego
public class CambioNivel : MonoBehaviour
{
    // Método que se llama cuando el GameObject con este script colisiona con otro GameObject
    public void OnCollisionEnter2D(Collision2D collision)
    { 
         // Verifica si el GameObject con el que colisionó tiene la etiqueta "Cambio"
        if(collision.gameObject.tag == "Cambio")
        {
            // Obtiene el índice de la escena actual
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            // Carga la siguiente escena en el índice de construcción de escenas
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "VictoryTrigger"
        if (other.CompareTag("Cambio"))
        {
            // Carga la escena de victoria utilizando la instancia del GameManager
            GameManager.Instance.CargarEscenaVictoria();
        }
    }
}
