using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class cronometro : MonoBehaviour
{

    [SerializeField] private UnityEvent Seacaboeltiempo;

    public float timeStar;
    public TextMeshProUGUI miTexto;

    bool timeActive = true;


    // Start is called before the first frame update
 void Start()
    {
        miTexto.text = timeStar.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive)
        {
            timeStar -= Time.deltaTime;
            miTexto.text = timeStar.ToString("F2");
        }

        if (timeStar <= 0) {

            Seacaboeltiempo.Invoke();
        }
    
    }

    public void PausarTiempo ()

    {
        timeActive =!timeActive;
    }




}