using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{   
    // Referencia al slider en la interfaz de usuario
    public Slider slider;
    // Valor actual del slider
    public float sliderValue;
    // Imagen para mostrar el estado de silencio
    public Image imagenMute;

    void Start()
    {   
        // Al inicio, establecer el valor del slider según lo almacenado en PlayerPrefs (o 0.5 si no hay valor guardado)
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        // Establecer el volumen del AudioListener según el valor actual del slider
        AudioListener.volume = slider.value;
        // Verificar y actualizar el estado del silencio
        RevisarMute();
    }
    // Método llamado cuando el valor del slider cambia
    public void ChangeSlider(float valor)
    {   
        // Actualizar el valor del sliderValue con el nuevo valor del slider
        sliderValue = valor;
        // Guardar el nuevo valor del volumen en PlayerPrefs
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        // Aplicar el nuevo volumen al AudioListener
        AudioListener.volume = slider.value;
        // Verificar y actualizar el estado del silencio
        RevisarMute();
    }
    // Método para verificar y actualizar el estado del silencio
    public void RevisarMute()
    {
        // Si el valor del slider es 0, mostrar la imagen de silencio
        if(sliderValue == 0)
        {
            imagenMute.enabled = true;
            // De lo contrario, ocultar la imagen de silencio
        }else{
            imagenMute.enabled = false;
        }
        
    }
}
