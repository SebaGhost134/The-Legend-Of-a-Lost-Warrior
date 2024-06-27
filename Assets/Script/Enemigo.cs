using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento del enemigo en el juego
public class Enemigo : MonoBehaviour
{
    // Referencia al GameObject del personaje (jugador)
    public GameObject Personaje;
    // Número de vidas del enemigo
    public int vidas;

    private float Disparo;

    // Update is called once per frame
    void Update()
    {
        // Calcula la dirección hacia el personaje
        Vector3 direccion = Personaje.transform.position - transform.position;
        // Verifica si el personaje está a la izquierda del enemigo
        if(direccion.x <=0.0f)
        {
            // Si el personaje está a la izquierda, establece la escala local del enemigo para que mire hacia la derecha
            transform.localScale = new Vector3 (1.0f , 1.0f , 1.0f);
        }
        else
        {
            // Si el personaje está a la derecha, establece la escala local del enemigo para que mire hacia la izquierda
            transform.localScale = new Vector3 (-1.0f , 1.0f , 1.0f);
        }

        float distance = Mathf.Abs(Personaje.transform.position.x - transform.position.x);

        if(distance <2.0f && Time.time > Disparo + 0.25f)
        {
            Shoot();
            Disparo = Time.time;
        }
    }
        // Método que se llama cuando este GameObject colisiona con otro GameObject
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Verifica si el GameObject con el que colisionó tiene la etiqueta "Player"
            if(other.gameObject.CompareTag("Player"))
            {
                // Llama al método PerderVida del GameManager
                GameManager.Instance.PerderVida();

                other.gameObject.GetComponent<Movimientovikingo>().AplicarGolpe();
            }
        }
        private void Shoot()
        {
            Debug.Log("te estoy disparando");
        }
}