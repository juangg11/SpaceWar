using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPmanager : MonoBehaviour
{
    [SerializeField] private float vidaActual;
    [SerializeField] private float vidaMaxima;
    public Image rellenoBarraHP;
    [SerializeField] private float intervaloDanio = 1.0f;
    private bool invulnerable = false;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        if (!invulnerable)
        {
            StartCoroutine(Invulnerabilidad(cantidad));
        }
    }

    private IEnumerator Invulnerabilidad(float cantidad)
    {
        invulnerable = true;
        vidaActual -= cantidad;
        if (vidaActual < 0) 
        {
            vidaActual = 0;
            //MORIR    
        }
        ActualizarBarraHP();
        yield return new WaitForSeconds(intervaloDanio);
        invulnerable = false;
    }

    private void ActualizarBarraHP()
    {
        rellenoBarraHP.fillAmount = vidaActual / vidaMaxima;
    }
}