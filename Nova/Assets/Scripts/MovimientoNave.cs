using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    [SerializeField] private float velocidad = 10.0f;
    public float horizontalMove;
    public float verticalMove;
    private Rigidbody2D player;
    [SerializeField] private GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalMove, verticalMove);
        player.velocity = moveDirection * velocidad;

        if (Input.GetMouseButtonDown(0))
        {
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