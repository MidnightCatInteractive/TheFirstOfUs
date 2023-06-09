using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;
    [SerializeField] private Transform orientation;

    private GameObject inventory;
    private float rotationX;
    private float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventory = GameObject.Find("Inventory");
    }

    void Update()
    {
        if (!PauseMenuScript.isPaused && !inventory.activeSelf)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX * Time.fixedDeltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.fixedDeltaTime;

            rotationX -= mouseY;
            rotationY += mouseX;

            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            orientation.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }
}
