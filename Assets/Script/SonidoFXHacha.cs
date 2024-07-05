using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFXHacha : MonoBehaviour
{   
    // Variable privada que contiene el clip de audio que se reproducirá al colectar el objeto.
    [SerializeField] private AudioClip colectar1;
    // Método que se llama cuando otro objeto entra en el trigger collider 2D adjunto a este objeto.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que ha entrado en el trigger collider tiene el tag "Player".
        if (other.CompareTag("Player"))
        {
            // Si es el jugador, llama al método "EjecutarSonido" de la instancia del "ControladorHacha",
            // pasándole el clip de audio "colectar1" para que se reproduzca.
            ControladorHacha.Instance.EjecutarSonido(colectar1);
            // Destruye este objeto (el hacha) del juego, simulando que ha sido recogido.
            Destroy(gameObject);
        }
    }
}