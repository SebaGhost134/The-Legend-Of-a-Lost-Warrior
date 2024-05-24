using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Clase que controla el menú de pausa del juego
public class MenuPausa : MonoBehaviour
{
    // Referencias a los botones y el menú de pausa en la interfaz de usuario
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    // Variable para controlar el estado de pausa del juego
    private bool juegoPausado = false;
    private void Update()
    {
        // Verifica si se ha presionado la tecla Escape
        if(Input.GetKeyDown(KeyCode.Escape)){
            // Si el juego está en pausa, reanuda el juego; de lo contrario, pone el juego en pausa
            if(juegoPausado)
            {
                Reanudar();
            }else{
                Pausa();
            }
        }
    }

    // Método para pausar el juego
    public void Pausa(){
        // Establece la variable de pausa a true
        juegoPausado = true;
        // Detiene el tiempo del juego
        Time.timeScale = 0f;
        // Desactiva el botón de pausa
        botonPausa.SetActive(false);
        // Activa el menú de pausa
        menuPausa.SetActive(true);
    }
 
    // Método para reanudar el juego
    public void Reanudar(){
        // Establece la variable de pausa a false
        juegoPausado = false;
        // Restablece el tiempo del juego
        Time.timeScale = 1f;
        // Activa el botón de pausa
        botonPausa.SetActive(true);
        // Desactiva el menú de pausa
        menuPausa.SetActive(false);
    }
    // Método para reiniciar el nivel actual
    public void Reiniciar(){
        // Establece la variable de pausa a false
        juegoPausado = false;
        // Restablece el tiempo del juego
        Time.timeScale = 1f;
        // Carga de nuevo la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Método para cerrar el juego y volver al menú principal
    public void Cerrar(){
        // Carga la escena del menú principal
        SceneManager.LoadScene("Menu");
    }
}
