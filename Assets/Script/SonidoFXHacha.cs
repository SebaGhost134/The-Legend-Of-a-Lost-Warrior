using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFXHacha : MonoBehaviour
{
    [SerializeField] private AudioClip colectar1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            ControladorHacha.Instance.EjecutarSonido(colectar1);
            Destroy(gameObject);
        }
    }
}