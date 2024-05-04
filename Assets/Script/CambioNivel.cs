using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.gameObject.tag == "Cambio")
        {
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}
