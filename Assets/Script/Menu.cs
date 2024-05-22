using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void BotonStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BotonQuit()
    {
        SceneManager.LoadScene("Menu");
    }
}
