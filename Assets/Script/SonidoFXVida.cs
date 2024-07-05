using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFXVida : MonoBehaviour
{
    [SerializeField] private AudioClip colectar2;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            ControladorVida.Instance.EjecutarSonido(colectar2);
            Destroy(gameObject);
        }
    }
}
