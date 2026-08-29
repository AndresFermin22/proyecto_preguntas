using UnityEngine;
using UnityEngine.UI;
using System.Collections; 

public class BotonRespuesta : MonoBehaviour
{
    [Header("Configuración de la Respuesta")]
    public bool esRespuestaCorrecta = false; 

    [Header("Navegación de Pantallas")]
    public GameObject pantallaActual;     // Pantalla 3
    public GameObject pantallaCorrecta;   // Pantalla 4
    public GameObject pantallaIncorrecta; // Pantalla 1

    [Header("Referencias")]
    public Temporizador temporizador; 

    private Image fondoBoton;

    void Start()
    {
        fondoBoton = GetComponent<Image>();
    }

    public void ComprobarRespuesta()
    {
        if (temporizador != null)
        {
            temporizador.DetenerTemporizador();
        }

        if (esRespuestaCorrecta)
        {
            fondoBoton.color = new Color(0.1f, 0.6f, 0.2f); // Verde
            StartCoroutine(CambiarPantallaConRetraso(pantallaCorrecta));
        }
        else
        {
            fondoBoton.color = new Color(0.8f, 0.2f, 0.2f); // Rojo
            StartCoroutine(CambiarPantallaConRetraso(pantallaIncorrecta));
        }
    }

    IEnumerator CambiarPantallaConRetraso(GameObject proximaPantalla)
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo exacto
        
        pantallaActual.SetActive(false); // Apaga la Pantalla 3
        proximaPantalla.SetActive(true); // Enciende la pantalla destino
    }
}