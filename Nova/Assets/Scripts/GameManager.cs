using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public float yFijo = 1.5f;
    public float tiempoEntreSpawns = 4f;

    private float[] posicionesX = { 0.1f, 6.19f, -1.83f, 4.18f, -3.81f, 2.2f, -5.84f };

    void Start()
    {
        InvokeRepeating("GenerarPrefab", 0f, tiempoEntreSpawns);
    }

    void GenerarPrefab()
    {
        float xAleatorio = posicionesX[Random.Range(0, posicionesX.Length)];
        Instantiate(prefab, new Vector3(xAleatorio, yFijo, 0), Quaternion.identity);
    }

    public static void DestruirTodosLosHijos(GameObject objetoPadre)
    {
    foreach (Transform hijo in objetoPadre.transform)
    {
        GameObject.Destroy(hijo.gameObject);
    }
    }
}
