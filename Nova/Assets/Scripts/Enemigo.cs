using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private HPmanager barraHP;
    [SerializeField] private int Danio;
    [SerializeField] private int Vida;
    [SerializeField] private int Velocidad;
    [SerializeField] private GameObject objetoDestruir;
    [SerializeField] private GameObject Explosion;
    private int Contador = 0;
    
    void Start()
    {
        barraHP = FindObjectOfType<HPmanager>();
    }

    void Update()
    {
        transform.position += new Vector3(0, -Velocidad * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Colision");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            barraHP.RecibirDanio(Danio);
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound("explosion");
            GameManager.DestruirTodosLosHijos(objetoDestruir);
            Destroy(objetoDestruir);
            Destroy(explosion, 0.35f);
        }

        if (other.gameObject.CompareTag("Bala"))
        {
            Debug.Log("Bala");
            Contador++;
            Destroy(other.gameObject);
            if (Contador == Vida)
            {
                Morir();
            }
        }
    }

    private void Morir()
    {
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        SoundManager.instance.PlaySound("explosion");
        GameManager.DestruirTodosLosHijos(objetoDestruir);
        Destroy(objetoDestruir);
        Puntuacion.SumarPuntos(10);
        Destroy(explosion, 0.35f);
    }
}
