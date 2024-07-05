using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento del enemigo en el juego
public class Enemigo : MonoBehaviour
{
    public GameObject Personaje; // Referencia al GameObject del personaje (jugador)
    public int vidas; // Número de vidas del enemigo

    public AudioClip sonidoDanio; // AudioClip para el sonido de daño al jugador
    private AudioSource audioSource; // Referencia al AudioSource para reproducir sonidos

    void Start()
    {
        // Obtener o agregar el AudioSource al mismo GameObject del enemigo
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Lógica de orientación del enemigo hacia el jugador
        Vector3 direccion = Personaje.transform.position - transform.position;
        if (direccion.x <= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    // Método que se llama cuando este GameObject colisiona con otro GameObject
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar si el GameObject con el que colisionó tiene la etiqueta "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Llama al método PerderVida del GameManager
            GameManager.Instance.PerderVida();

            // Aplica un golpe al jugador (esto depende de tu implementación en Movimientovikingo)
            other.gameObject.GetComponent<Movimientovikingo>().AplicarGolpe();

            // Reproduce el sonido de daño al jugador si está asignado
            if (sonidoDanio != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoDanio);
            }
        }
    }

    public void Hit()
    {
        // Reduce la cantidad de vidas del enemigo
        vidas--;

        // Si las vidas llegan a cero, destruye el enemigo
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }
}