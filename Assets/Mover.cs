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

    // Animator component'i ekle
    public Animator animator;

    // Worm'un mevcut yönünü kaydetmek için bir deðiþken oluþtur
    Vector3 currentDirection;

    // Worm'un yönünü deðiþtirmek için bir deðiþken oluþtur
    bool isTurned = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Movement");

        // Animator component'ini al
        animator = worm.GetComponent<Animator>();

        // Worm'un mevcut yönünü kaydet
        currentDirection = moveAction.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // Worm hareket ediyorsa
        if (moveAction.ReadValue<Vector2>().magnitude > 0)
        {
            MovePlayer();
        }
        else
        {
            // Worm hareket etmiyorsa animasyonu durdur
            animator.SetBool("isMoving", false);
        }
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        worm.transform.position = new Vector3(worm.transform.position.x, -3.78f, 0);
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;

        // Worm'un animasyonunu oynat
        animator.SetBool("isMoving", true);

        // Worm'un yönünü deðiþtir
        if (direction.x > 0)
        {
            // Worm'u y ekseninde 180 derece döndür
            if (currentDirection.x < 1)
            {
                worm.transform.rotation = Quaternion.Euler(0, 90, 0);
                isTurned = true;
            }
        }
        else if (direction.x < 0)
        {
            // Worm'u y ekseninde 180 derece döndür
            if (isTurned)
            {
                worm.transform.localRotation = Quaternion.Euler(0, -90, 0);
                isTurned = false;
            }
        }
    }

    void OnDisable()
    {
        // Worm'un animasyonunu durdur
        animator.SetBool("isMoving", false);
    }
}
