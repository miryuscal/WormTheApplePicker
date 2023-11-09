using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    public GameObject worm;
    public AudioSource audioSource;
    public AudioClip audioClip;


    public static float speed = 5;

    // Animator component'i ekle
    public Animator animator;

    // Worm'un mevcut yönünü kaydetmek için bir deðiþken oluþtur
    Vector3 currentDirection;

    // Worm'un yönünü deðiþtirmek için bir deðiþken oluþtur
    bool isTurned = false;
    public Rigidbody wormRigidBody;
    Vector3 eulerAngles;

    void Start()
    {
        audioSource.PlayOneShot(audioClip);
        Application.targetFrameRate = 60;
        eulerAngles = wormRigidBody.transform.rotation.eulerAngles;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Movement");

        // Animator component'ini al
        animator = worm.GetComponent<Animator>();

        // Worm'un mevcut yönünü kaydet
        currentDirection = moveAction.ReadValue<Vector2>();
        wormRigidBody.centerOfMass = worm.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        eulerAngles.z = 0;
        worm.transform.position = new Vector3(worm.transform.position.x, -3.78f, 0);
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
        transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;

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
