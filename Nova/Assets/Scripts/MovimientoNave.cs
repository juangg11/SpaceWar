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
    [SerializeField] public bool mejoraDash = false;
    private bool puedeDash;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        puedeDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        Controles();
        Comprobar();
    }

    private IEnumerator borrar(GameObject balaInstanciada)
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(balaInstanciada);
    }

    public void Controles()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalMove, verticalMove);
        player.velocity = moveDirection * velocidad;

        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.PlaySound("jump");
            GameObject balaInstanciada = Instantiate(bala, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            StartCoroutine(borrar(balaInstanciada));
        }

        if (Input.GetKeyDown(KeyCode.Space) && mejoraDash && puedeDash)
        {
            StartCoroutine(Dash(moveDirection));
        }
    }

    private IEnumerator Dash(Vector2 direction)
    {
        puedeDash = false;
        float dashSpeed = 20f;
        float dashTime = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            player.velocity = direction.normalized * dashSpeed;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.velocity = Vector2.zero;
        yield return new WaitForSeconds(5.0f);
        puedeDash = true;
    }

    public void Comprobar()
    {
        if (gameObject.transform.position.y < -4.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4.5f, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x > 8.3f)
        {
            gameObject.transform.position = new Vector3(8.3f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y > 4.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 4.5f, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x < -8.3f)
        {
            gameObject.transform.position = new Vector3(-8.3f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}