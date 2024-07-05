using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour
{
    // Array de posiciones a las que la plataforma se moverá.
    public Transform[] Pose;
    // Velocidad de movimiento de la plataforma.
    public float speed;
    // Identificador de la posición actual en el array Pose.
    public int ID;
    // Variable para determinar la dirección del movimiento.
    // Suma = 1 significa que se moverá hacia adelante en el array, Suma = -1 significa que se moverá hacia atrás.
    public int Suma;
    // Start is called before the first frame update
    void Start()
    {
    // Establece la posición inicial de la plataforma en la primera posición del array Pose.
      transform.position = Pose[0].position;  
    }

    // Update is called once per frame
    void Update()
    {   // Comprueba si la plataforma ha llegado a la posición destino actual.
        if(transform.position == Pose[ID].position){
            // Incrementa o decrementa el ID basado en el valor de Suma.
            ID += Suma;
        }
        // Si la plataforma ha llegado a la última posición del array Pose,
        // cambia la dirección de movimiento hacia atrás.
        if(ID == Pose.Length-1)
        {
            Suma = -1;
        }
        // Si la plataforma ha llegado a la primera posición del array Pose,
        // cambia la dirección de movimiento hacia adelante.
        if(ID == 0){
            Suma = 1;
        }
        // Mueve la plataforma hacia la posición destino actual a la velocidad especificada.
        transform.position = Vector3.MoveTowards(transform.position, Pose[ID].position, speed * Time.deltaTime);
    }
}
