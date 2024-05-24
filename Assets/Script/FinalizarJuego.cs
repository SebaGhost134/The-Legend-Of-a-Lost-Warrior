using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizarJuego : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D collision)
    { 
        Debug.Log("final");
    }
}
