using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFXVida : MonoBehaviour
{
     // Variable privada que contiene el clip de audio que se reproducirá al colectar el objeto.
    [SerializeField] private AudioClip colectar2;
    // Método que se llama cuando otro objeto entra en el trigger collider 2D adjunto a este objeto.
    private void OnTriggerEnter2D(Collider2D other)
    {   
        // Comprueba si el objeto que ha entrado en el trigger collider tiene el tag "Player".
        if (other.CompareTag("Player"))
        {   
            // Si es el jugador, llama al método "EjecutarSonido" de la instancia del "ControladorVida",
            // pasándole el clip de audio "colectar2" para que se reproduzca.
            ControladorVida.Instance.EjecutarSonido(colectar2);
            // Destruye este objeto (la vida extra) del juego, simulando que ha sido recogido.
            Destroy(gameObject);
        }
    }
}
