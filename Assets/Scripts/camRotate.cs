using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camRotate : MonoBehaviour
{
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] float mouseSensitivity = 3.5f;
    float cameraPitch = 0.0f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    Camera playerCamera;
    GameObject pCam;
    Rigidbody rb;

    private void Start()
    {
        pCam = GameObject.FindWithTag("2ndCam");
        playerCamera = pCam.GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector2 targetMouseDelta = Mouse.current.delta.ReadValue() * Time.smoothDeltaTime;
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        float yaw = pCam.transform.eulerAngles.y + currentMouseDelta.x * mouseSensitivity;
        pCam.transform.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
        rb.transform.localEulerAngles = new Vector3(0f, yaw, 0f);
       // rb.transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
}
