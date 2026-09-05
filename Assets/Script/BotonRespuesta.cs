using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonRespuesta : MonoBehaviour
{
    [Header("Configuración de la Respuesta")]
    public bool esRespuestaCorrecta = false;

    [Header("Navegación de Pantallas")]
    public GameObject pantallaActual;
    public GameObject pantallaCorrecta;
    public GameObject pantallaIncorrecta;

    [Header("Referencias")]
    public Temporizador temporizador;
    public GestorPuntaje gestorPuntaje; // <--- NUEVA REFERENCIA AL PUNTAJE

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

            // Sumamos los 1000 puntos
            if (gestorPuntaje != null)
            {
                gestorPuntaje.SumarPuntos(1000);
            }

            StartCoroutine(CambiarPantallaConRetraso(pantallaCorrecta));
        }
        else
        {
            fondoBoton.color = new Color(0.8f, 0.2f, 0.2f); // Rojo

            // Si quieres sumar 0 puntos, puedes dejarlo así, o simplemente no llamar a la función
            if (gestorPuntaje != null)
            {
                gestorPuntaje.SumarPuntos(0);
            }

            StartCoroutine(CambiarPantallaConRetraso(pantallaIncorrecta));
        }
    }

    IEnumerator CambiarPantallaConRetraso(GameObject proximaPantalla)
    {
        yield return new WaitForSeconds(1f);

        pantallaActual.SetActive(false);
        proximaPantalla.SetActive(true);
    }
}