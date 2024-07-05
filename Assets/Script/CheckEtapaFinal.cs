using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEtapaFinal : MonoBehaviour
{
    // Nombre de la escena del menú principal que se cargará
    public string mainMenu;

    // Cargar la escena del menú principal
    public void MainMenu(){
        SceneManager.LoadScene(mainMenu);
    }
}
