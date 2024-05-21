using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject Personaje;

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = Personaje.transform.position - transform.position;
        if(direccion.x <=0.0f)
        {
            transform.localScale = new Vector3 (1.0f , 1.0f , 1.0f);
        }
        else
        {
            transform.localScale = new Vector3 (-1.0f , 1.0f , 1.0f);
        }


    }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.PerderVida();
            }
        }

    
}