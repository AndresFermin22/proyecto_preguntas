using UnityEngine;
using TMPro; // Necesario para modificar tu texto de TextMeshPro

public class GestorPuntaje : MonoBehaviour
{
    public int puntajeTotal = 0;
    public TMP_Text textoPuntajeFinal; // El texto que está en la Pantalla 4

    // Esta función suma los puntos y actualiza la pantalla
    public void SumarPuntos(int cantidad)
    {
        puntajeTotal += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoPuntajeFinal != null)
        {
            // Cambia el texto para que diga el puntaje. 
            // Puedes ajustarlo para que solo diga el número o incluya texto.
            textoPuntajeFinal.text = puntajeTotal.ToString();
        }
    }
}