using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que controla las acciones del menú del juego
public class Menu : MonoBehaviour
{
    // Método que se llama cuando se presiona el botón de iniciar el juego
    public void BotonStart()
    {
        // Carga la escena llamada "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }

    // Método que se llama cuando se presiona el botón de salir del juego
    public void BotonQuit()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("Menu");
    }
}
