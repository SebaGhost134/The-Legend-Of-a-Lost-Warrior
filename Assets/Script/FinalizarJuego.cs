using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla la finalización del juego
public class FinalizarJuego : MonoBehaviour
{
    
    // Método que se llama cuando este GameObject colisiona con otro GameObject
    public void OnCollisionEnter2D(Collision2D collision)
    { 
        // Imprime un mensaje de "final" en la consola de depuración
        Debug.Log("final");
    }
}
