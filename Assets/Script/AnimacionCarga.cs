using UnityEngine;
using UnityEngine.UI; // Necesario para modificar las imágenes
using System.Collections;

public class AnimacionCarga : MonoBehaviour
{
    [Header("Configuración de los Puntos")]
    public Image[] puntos; // Aquí guardaremos los 4 puntos
    public Color colorEncendido = new Color(1f, 0.6f, 0f); // Color naranja
    public Color colorApagado = new Color(0.15f, 0.2f, 0.35f); // Color azul oscuro
    public float velocidadAnimacion = 0.4f; // Tiempo en segundos entre cada cambio

    void Start()
    {
        // Iniciamos la animación apenas aparezca esta pantalla
        StartCoroutine(AnimarPuntos());
    }

    IEnumerator AnimarPuntos()
    {
        int indiceActual = 0;

        while (true) // Bucle infinito para que la animación no se detenga
        {
            // 1. Apagamos todos los puntos primero
            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i].color = colorApagado;
            }

            // 2. Encendemos únicamente el punto que toca en este turno
            if (puntos.Length > 0)
            {
                puntos[indiceActual].color = colorEncendido;
            }

            // 3. Pasamos al siguiente punto (si llega al final, vuelve a empezar)
            indiceActual++;
            if (indiceActual >= puntos.Length)
            {
                indiceActual = 0;
            }

            // 4. Esperamos el tiempo indicado antes de repetir el ciclo
            yield return new WaitForSeconds(velocidadAnimacion);
        }
    }
}