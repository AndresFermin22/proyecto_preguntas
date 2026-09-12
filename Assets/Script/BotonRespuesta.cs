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
    public GestorPuntaje gestorPuntaje;

    private Image fondoBoton;

    void Start()
    {
        fondoBoton = GetComponent<Image>();
    }

    public void ComprobarRespuesta()
    {
        // Detenemos el reloj y obtenemos los segundos exactos consumidos
        if (temporizador != null && gestorPuntaje != null)
        {
            float tiempoGastado = temporizador.DetenerYObtenerTiempoUsado();
            gestorPuntaje.RegistrarTiempoConsumido(tiempoGastado);
        }

        if (esRespuestaCorrecta)
        {
            fondoBoton.color = new Color(0.1f, 0.6f, 0.2f); // Verde

            if (gestorPuntaje != null)
            {
                gestorPuntaje.SumarPuntos(1000);
            }

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
        yield return new WaitForSeconds(1f);

        pantallaActual.SetActive(false);
        proximaPantalla.SetActive(true);
    }
}