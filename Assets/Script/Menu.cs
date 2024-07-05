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
     public void Instructivo()
    {
        // Carga la escena del instructivo llamada "Instructivo"
        SceneManager.LoadScene("Instructivo");
    }
    public void Nivel1()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("SampleScene");
    }
    public void Nivel2()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("Cueva");
    }
    public void Nivel3()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("Nieve");
    }
    public void nivel()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("Niveles");
    }
    public void Salir()
    {
        // Carga la escena del menú principal llamada "Menu"
        Application.Quit();
    }
    public void Minijuego1()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("Minijuego Llanura");
    }
    public void Minijuego2()
    {
        // Carga la escena del menú principal llamada "Menu"
        SceneManager.LoadScene("MinijuegoNieve");
    }

}
