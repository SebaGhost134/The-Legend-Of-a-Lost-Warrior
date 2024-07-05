using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el movimiento del vikingo
public class Movimientovikingo : MonoBehaviour
{
    // Prefab de la bala que disparará el vikingo
    public GameObject BulletPrefab;
     // Fuerza con la que el vikingo saltará
    public float fuerzaSalto;
    // Componente Animator del vikingo
    private Animator Animator;
    // Variable que almacena el valor de la entrada horizontal
    private float horizontal;
    // Variable que indica si el vikingo mira a la derecha
    private bool mirarDerecha=true;
     // Componente Rigidbody2D para manejar la física del movimiento
    private Rigidbody2D movimiento;
     // Variable que indica si el vikingo puede saltar
    private bool salto;
    // Velocidad de movimiento horizontal del vikingo
    public float velocidad;
    // Momento en el tiempo del último disparo
    public float LastShoot;
    public float fuerzaGolpe;
    private Rigidbody2D rigidBody;

    // Start es lo que se inicia en la clase
    void Start()
    {
         // Obtiene el componente Rigidbody2D del vikingo
        movimiento = GetComponent<Rigidbody2D>();
         // Obtiene el componente Animator del vikingo
        Animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update se ejecuta mientras el freim se actualiza
    void Update()
    {
        //Se define para que el Vikingo sólo camine de forma horizontal usando las Letras A/D
        horizontal = Input.GetAxisRaw("Horizontal");
        // Actualiza la variable "running" del Animator dependiendo si hay movimiento horizontal
        Animator.SetBool("running", horizontal != 0.0f);
        // Verifica si el vikingo está tocando el suelo usando un Raycast
        if(Physics2D.Raycast(transform.position,Vector3.down,1.1f))
        {
            salto = true;
        }
        else
        {
            salto = false;
        }
        // Si se presiona la tecla W y el vikingo puede saltar, llama al método Saltar
        if (Input.GetKeyDown(KeyCode.W)&& salto){
            Saltar();
        }
        // Llama al método Flip para manejar la orientación del vikingo
        Flip();
        // Si se mantiene presionada la barra espaciadora y ha pasado suficiente tiempo desde el último disparo
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    // Método para manejar el salto del vikingo
    private void Saltar()
    {
        // Cambia la velocidad vertical del Rigidbody2D para hacer que el vikingo salte
        movimiento.velocity=new Vector2(movimiento.velocity.x,fuerzaSalto);
    }
    // Método para manejar el disparo del vikingo
    private void Shoot()
    {
        Vector3 direction;
        // Determina la dirección del disparo dependiendo de la orientación del vikingo
        if(transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
            // Instancia una bala en la posición adecuada y con la orientación correcta
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *1.0f, Quaternion.identity);
            bullet.transform.localScale = new Vector3(1.0f , 1.0f , 1.0f);
            bullet.GetComponent<BalaPoder>().SetDirection(direction);
        }
        else
        {
            direction = Vector3.left;
            // Instancia una bala en la posición adecuada y con la orientación correcta
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *1.0f, Quaternion.identity);
            bullet.transform.localScale = new Vector3(-1.0f , 1.0f , 1.0f);
            bullet.GetComponent<BalaPoder>().SetDirection(direction);

        } 

    }

    // Método para manejar la orientación del vikingo
    private void Flip()
    {
        // Cambia la dirección en la que mira el vikingo dependiendo de la entrada horizontal
        if(mirarDerecha && horizontal<0f || !mirarDerecha && horizontal >0f){
           Vector3 localScale=transform.localScale;
           mirarDerecha=! mirarDerecha;
           localScale.x*=-1f;
           transform.localScale=localScale; 
        }
    }
    // Método que se llama en intervalos de tiempo fijos para manejar la física
    private void FixedUpdate()
    {
        // Actualiza la velocidad del Rigidbody2D para mover al vikingo horizontalmente
        movimiento.velocity = new Vector2(horizontal*velocidad,movimiento.velocity.y);
    }
    public void AplicarGolpe()
    {
        Vector2 direccionGolpe;

            if (rigidBody.velocity.x > 0)
            {
                direccionGolpe = new Vector2(-1, 1);
            }
            else
            {
                direccionGolpe = new Vector2(1, 1);
            }

            // Limitar la fuerza aplicada
            float fuerzaAplicada = Mathf.Min(fuerzaGolpe, 10.0f); // Ajusta 10.0f según sea necesario

            rigidBody.AddForce(direccionGolpe * fuerzaAplicada, ForceMode2D.Impulse);

            // Limitar la velocidad máxima después del golpe
            float velocidadMaxima = 5.0f; // Ajusta 5.0f según sea necesario
            rigidBody.velocity = new Vector2(
                Mathf.Clamp(rigidBody.velocity.x, -velocidadMaxima, velocidadMaxima),
                Mathf.Clamp(rigidBody.velocity.y, -velocidadMaxima, velocidadMaxima)
            );
    }
}
    
