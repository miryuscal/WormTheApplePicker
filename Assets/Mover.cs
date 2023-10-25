using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public GameObject worm;

    public float speed = 5;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        worm.transform.position = new Vector3(worm.transform.position.x, -3.78f, 0);
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }



}
