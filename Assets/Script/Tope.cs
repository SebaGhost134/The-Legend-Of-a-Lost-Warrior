using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente SpriteRenderer adjunto a este GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // Verificar si se encontró un SpriteRenderer
        if (spriteRenderer != null)
        {   
            // Desactivar la visibilidad del SpriteRenderer
            spriteRenderer.enabled = false;
        } 
    }
}
