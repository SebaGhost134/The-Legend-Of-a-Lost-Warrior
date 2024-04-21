using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientovikingo : MonoBehaviour
{
    public float fuerzaSalto;
    private Animator Animator;
    private float horizontal;
    private bool mirarDerecha=true;
    private Rigidbody2D movimiento;
    private bool salto;
    public float velocidad;
    public Transform transform;

    // Start es lo que se inicia en la clase
    void Start()
    {
        movimiento = GetComponent<Rigidbody2D>();
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
            Saltar();
        }
        Flip();
    }

    private void Saltar()
    {
        movimiento.velocity=new Vector2(movimiento.velocity.x,fuerzaSalto);
    }

    private void Flip()
    {
        if(mirarDerecha && horizontal<0f || !mirarDerecha && horizontal >0f){
           Vector3 localScale=transform.localScale;
           mirarDerecha=! mirarDerecha;
           localScale.x*=-1f;
           transform.localScale=localScale; 
        }
    }
    private void FixedUpdate()
    {
        movimiento.velocity = new Vector2(horizontal*velocidad,movimiento.velocity.y);
    }
}
    
