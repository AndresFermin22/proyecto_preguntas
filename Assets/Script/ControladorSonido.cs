using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public AudioSource fuenteDeAudio;
    public AudioClip sonidoClic;

    public void ReproducirSonidoBoton()
    {
        fuenteDeAudio.PlayOneShot(sonidoClic);
    }
}