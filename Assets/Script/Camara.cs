using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento de la cámara
public class Camara : MonoBehaviour
{
    // Referencia al GameObject del vikingo
    public GameObject Vikingo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtiene la posición actual de la cámara
        Vector3 position = transform.position;
        // Ajusta la posición x de la cámara para que siga al vikingo en el eje x
        position.x = Vikingo.transform.position.x;
        // Ajusta la posición y de la cámara para que siga al vikingo en el eje y
        position.y = Vikingo.transform.position.y;
        // Establece la nueva posición de la cámara
        transform.position = position;
    }
}
