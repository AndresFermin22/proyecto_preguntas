using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempoRestante = 10f; 
    public TMP_Text textoTemporizador; 
    private bool cronometroActivo = false;

    [Header("Navegación si se acaba el tiempo")]
    public GameObject pantallaActual;  // Pantalla 3
    public GameObject pantallaDerrota; // Pantalla 1

    void OnEnable()
    {
        tiempoRestante = 10f;
        cronometroActivo = true; 
    }

    void Update()
    {
        if (cronometroActivo)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime; 
                ActualizarTexto(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                cronometroActivo = false;
                ActualizarTexto(tiempoRestante);
                
                pantallaActual.SetActive(false);
                pantallaDerrota.SetActive(true);
            }
        }
    }

    void ActualizarTexto(float tiempo)
    {
        float segundos = Mathf.CeilToInt(tiempo);
        textoTemporizador.text = segundos.ToString();
    }

    public void DetenerTemporizador()
    {
        cronometroActivo = false;
    }
}