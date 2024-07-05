using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVida : MonoBehaviour
{
     // Instancia estática única del ControladorVida
    public static ControladorVida Instance;
    // Referencia al AudioSource adjunto al GameObject
    private AudioSource audioSource;

    private void Awake(){
        // Verificar si ya hay una instancia creada
        if(Instance == null){
            // Si no hay otra instancia, establecer esta como la instancia única
            Instance = this;
            // Mantener este GameObject activo al cargar nuevas escenas
            DontDestroyOnLoad(gameObject);
        }else{
            // Si ya hay una instancia, destruir este GameObject para evitar duplicados
            Destroy(gameObject);
        }
        // Obtener referencia al AudioSource del GameObject actual
        audioSource = GetComponent<AudioSource>();
    }
    // Método para ejecutar un sonido dado
    public void EjecutarSonido(AudioClip sonido){
        // Reproducir el sonido una sola vez usando PlayOneShot
        audioSource.PlayOneShot(sonido);
    }
}
