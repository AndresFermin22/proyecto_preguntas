using UnityEngine;
using TMPro;

public class GestorPuntaje : MonoBehaviour
{
    public int puntajeTotal = 0;
    public float tiempoTotalTranscurrido = 0f;

    [Header("Referencias UI Pantalla 4")]
    public TMP_Text textoPuntajeFinal;
    public TMP_Text textoTiempoTotal;

    public void SumarPuntos(int cantidad)
    {
        puntajeTotal += cantidad;
        ActualizarUIPuntaje();
    }

    public void RegistrarTiempoConsumido(float tiempoConsumido)
    {
        tiempoTotalTranscurrido += tiempoConsumido;
        ActualizarUITiempo();
    }

    void ActualizarUIPuntaje()
    {
        if (textoPuntajeFinal != null)
        {
            textoPuntajeFinal.text = puntajeTotal.ToString();
        }
    }

    void ActualizarUITiempo()
    {
        if (textoTiempoTotal != null)
        {
            int minutos = Mathf.FloorToInt(tiempoTotalTranscurrido / 60);
            int segundos = Mathf.FloorToInt(tiempoTotalTranscurrido % 60);

            textoTiempoTotal.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }
}