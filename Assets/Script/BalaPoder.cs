using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento de la bala
public class BalaPoder : MonoBehaviour
{
    // Velocidad de la bala
    public float Speed;
    // Componente Rigidbody2D de la bala para manejar la física
    private Rigidbody2D Rigidbody2D;
    // Dirección en la que se mueve la bala
    private Vector2 Direction;
    // Clip de audio que se reproduce cuando se dispara la bala
    public AudioClip sonidoFX;
    
    void Start()
    {
        // Obtiene el componente Rigidbody2D de la bala
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Reproduce el sonido del disparo usando el AudioSource principal de la cámara
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoFX);
    }

    private void FixedUpdate()
    {
        // Establece la velocidad del Rigidbody2D para mover la bala en la dirección deseada
        Rigidbody2D.velocity = Direction * Speed;
    }

    // Método para establecer la dirección de la bala
    public void SetDirection(Vector2 direction)
    {
        // Asigna la dirección pasada como parámetro a la dirección de la bala
        Direction = direction;
    }

    // Método para destruir la bala
    public void DestruirBala()
    {
        // Destruye el GameObject de la bala
        Destroy(gameObject);
    }


}
