using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 10f;
    public float tiempoRestante = 10f;
    public TMP_Text textoTemporizador;
    private bool cronometroActivo = false;

    [Header("Navegación si se acaba el tiempo")]
    public GameObject pantallaActual;
    public GameObject pantallaDerrota;

    public GestorPuntaje gestorPuntaje;

    void OnEnable()
    {
        tiempoRestante = tiempoInicial;
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

                if (gestorPuntaje != null)
                {
                    gestorPuntaje.RegistrarTiempoConsumido(tiempoInicial);
                }

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

    public float DetenerYObtenerTiempoUsado()
    {
        cronometroActivo = false;
        float tiempoUsado = tiempoInicial - tiempoRestante;
        return tiempoUsado;
    }
}