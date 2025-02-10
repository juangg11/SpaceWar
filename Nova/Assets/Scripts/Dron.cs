using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    private Rigidbody2D rb = new Rigidbody2D();
    public GameObject nave;
    private Vector2 offset; 
    [SerializeField] public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CambiarDireccion());
        StartCoroutine(Disparar());
        offset = transform.position - nave.transform.position;
    }
    void MoverArriba()
    {
        rb.velocity = new Vector2(0, 0.5f);
    }

    void MoverAbajo()
    {
        rb.velocity = new Vector2(0, -0.5f);
    }

    void Update()
    {
        Vector3 nuevaPos = new Vector3(nave.transform.position.x + offset.x, nave.transform.position.y + offset.y, transform.position.z);
        transform.position = nuevaPos;
    }
    IEnumerator CambiarDireccion()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            MoverArriba();
            yield return new WaitForSeconds(0.3f);
            MoverAbajo();
        }
    }

    IEnumerator Disparar()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            SoundManager.instance.PlaySound("disparo");
            GameObject balaInstanciada = Instantiate(bala, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            StartCoroutine(borrar(balaInstanciada));
        }
    }

    private IEnumerator borrar(GameObject balaInstanciada)
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(balaInstanciada);
    }
}
