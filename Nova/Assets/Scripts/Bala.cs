using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 20.0f;
    Rigidbody2D rb = new Rigidbody2D();
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, velocidad);
    }
}
