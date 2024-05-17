using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientovikingo : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float fuerzaSalto;
    private Animator Animator;
    private float horizontal;
    private bool mirarDerecha=true;
    private Rigidbody2D movimiento;
    private bool salto;
    public float velocidad;
    public float LastShoot;

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

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Saltar()
    {
        movimiento.velocity=new Vector2(movimiento.velocity.x,fuerzaSalto);
    }

    private void Shoot()
    {
        Vector3 direction;
        if(transform.position.x == 1.0f)
        {
            direction = Vector3.right;
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *1.0f, Quaternion.identity);
           // bullet.transform.localScale = new Vector3(0.5f , 0.5f , 0.5f);
            print("Derecha");
            bullet.GetComponent<BalaPoder>().SetDirection(direction);
        }
        else
        {
            direction = Vector3.left;
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *1.0f, Quaternion.identity);
            //bullet.transform.localScale = new Vector3(-0.5f , 0.5f , 0.5f);
            print("isquierda");
            bullet.GetComponent<BalaPoder>().SetDirection(direction);

        } 

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
    
