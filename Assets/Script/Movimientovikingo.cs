using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientovikingo : MonoBehaviour
{
    public float fuerzaSalto;
    private Animator Animator;
    private float horizontal;
    private Rigidbody2D movimineto;
    private bool salto;
    public float velosidad;


    // Start es lo que se inicia en la clase
    void Start()
    {
        movimineto = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update se ejecuta mientras el freim se actualiza
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("running", horizontal != 0.0f);

        //Debug.DrawRay(transform.position, Vector3.down*0.9f, Color.red);
        if(Physics2D.Raycast(transform.position,Vector3.down,1.1f))
        {
            salto = true;
        }
        else
        {
            salto = false;
        }


        if (Input.GetKeyDown(KeyCode.W)&& salto){
            saltar();
        }
        
    }

    private void saltar()
    {
        movimineto.AddForce(Vector2.up*fuerzaSalto);
    }

    private void FixedUpdate()
    {
        movimineto.velocity = new Vector2(horizontal*velosidad,movimineto.velocity.y);
    }
}
    
