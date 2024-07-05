using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{	
	// Este método se llama cuando el Collider2D de este objeto entra en contacto con otro Collider2D
    private void OnTriggerEnter2D(Collider2D other) {
		// Verificar si el otro objeto tiene la etiqueta "Player"
		if(other.gameObject.CompareTag("Player"))
		{	
			// Intentar recuperar vida a través del GameManager y guardar el resultado
			bool vidaRecuperada = GameManager.Instance.RecuperarVida();
			// Si se recuperó vida exitosamente según el GameManager
			if(vidaRecuperada) {
				// Destruir este objeto (que es el que contiene el script Vida)
				Destroy(this.gameObject);
			}
		}
	}
}
