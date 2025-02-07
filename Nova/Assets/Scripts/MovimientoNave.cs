using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    [SerializeField] private float velocidad = 10.0f;
    public float horizontalMove;
    public float verticalMove;
    private CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(0, verticalMove);
        moveDirection = transform.TransformDirection(moveDirection);
        player.Move(moveDirection * velocidad * Time.deltaTime);

        Vector2 moveDirection2 = new Vector2(horizontalMove, 0);
        moveDirection2 = transform.TransformDirection(moveDirection2);
        player.Move(moveDirection2 * velocidad * Time.deltaTime);
    }
}
