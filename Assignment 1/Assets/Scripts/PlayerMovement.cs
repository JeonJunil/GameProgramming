using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.Q)) { transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); }
    }
}