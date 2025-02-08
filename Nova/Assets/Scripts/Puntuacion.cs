using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public static int puntuacion;
    [SerializeField] private TextMesh texto;

    public static void SumarPuntos(int puntos)
    {
        puntuacion += puntos;
        ActualizarPuntuacionStatic();
    }

    public void ActualizarPuntuacion()
    {
        texto.text = "" + puntuacion;
    }

    public static void ActualizarPuntuacionStatic()
    {
        Puntuacion instance = FindObjectOfType<Puntuacion>();
        if (instance != null)
        {
            instance.ActualizarPuntuacion();
        }
    }
}