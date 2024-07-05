using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float fallDelay = 0.3f;
    public float ShakeAmount = 5f;
    public float destroyDelay = 2.0f; // Tiempo después de caer para destruir la plataforma
    bool readyToShake = false;

    Rigidbody2D rb;
    Vector3 originalPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShake)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * ShakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Falling(fallDelay));
        }
    }

    IEnumerator Falling(float delay)
    {
        originalPos = transform.position;
        yield return new WaitForSeconds(delay);
        readyToShake = true;
        yield return new WaitForSeconds(1.0f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay); // Esperar antes de destruir la plataforma
        Destroy(gameObject); // Destruir la plataforma
    }
}