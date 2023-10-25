using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject worm;
    private CharacterController characterController;

    public float speed = 0.5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        characterController.Move(move * Time.deltaTime * speed);
        worm.transform.position = new Vector3(worm.transform.position.x, -3.78f, 0);

    }

   
}
