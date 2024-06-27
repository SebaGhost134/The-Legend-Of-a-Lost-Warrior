using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

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
}
