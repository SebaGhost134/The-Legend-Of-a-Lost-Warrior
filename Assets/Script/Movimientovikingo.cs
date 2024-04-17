using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientovikingo : MonoBehaviour
{
    public float fuerzaSalto;
    private float horizontal;
    private Rigidbody2D movimineto;


    // Start es lo que se inicia en la clase
    void Start()
    {
        movimineto = GetComponent<Rigidbody2D>();
    }

    // Update se ejecuta mientras el freim se actualiza
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W)){
            saltar();
        }
        
    }

    private void saltar()
    {
        movimineto.AddForce(Vector2.up*fuerzaSalto);
    }

    private void FixedUpdate()
    {
        movimineto.velocity = new Vector2(horizontal,movimineto.velocity.y);
    }
}
    
