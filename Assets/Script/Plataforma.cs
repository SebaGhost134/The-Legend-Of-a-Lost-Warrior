using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
     // Tiempo de espera antes de que la plataforma comience a caer
    public float fallDelay = 0.3f;
    // Magnitud del temblor cuando la plataforma está lista para caer
    public float ShakeAmount = 5f;
    // Tiempo después de caer para destruir la plataforma
    public float destroyDelay = 2.0f; 
    // Indica si la plataforma está lista para temblar
    bool readyToShake = false;
    // Referencia al Rigidbody2D de la plataforma
    Rigidbody2D rb;
    // Posición original de la plataforma
    Vector3 originalPos;

    void Start()
    {
        // Obtener el componente Rigidbody2D al inicio
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShake)
        {
            // Calcular una nueva posición temblorosa
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * ShakeAmount);
            // Mantener la misma posición en y
            newPos.y = transform.position.y;
            // Mantener la misma posición en z
            newPos.z = transform.position.z;
            // Aplicar la nueva posición temblorosa
            transform.position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Iniciar la rutina de caída de la plataforma
            StartCoroutine(Falling(fallDelay));
        }
    }

    IEnumerator Falling(float delay)
    {
        // Almacenar la posición original de la plataforma
        originalPos = transform.position;
        // Esperar el tiempo especificado antes de continuar
        yield return new WaitForSeconds(delay);
        // Marcar la plataforma como lista para temblar
        readyToShake = true;
        // Esperar un segundo antes de continuar
        yield return new WaitForSeconds(1.0f);
        // Cambiar el tipo de cuerpo a dinámico para que la plataforma caiga
        rb.bodyType = RigidbodyType2D.Dynamic;
        // Esperar antes de destruir la plataforma
        yield return new WaitForSeconds(destroyDelay); 
        // Destruir la plataforma
        Destroy(gameObject);
    }
}