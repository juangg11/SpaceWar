using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] public HPmanager barraHP;
    [SerializeField] private int Danio;
    [SerializeField] private int Vida;
    private int Contador = 0;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Colision");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            barraHP.RecibirDanio(Danio);
        }

        if (other.gameObject.CompareTag("Bala"))
        {
            Debug.Log("Bala");
            Contador++;
            if (Contador == Vida)
            {
                Morir();
            }
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
        Puntuacion.SumarPuntos(10);
    }
}
