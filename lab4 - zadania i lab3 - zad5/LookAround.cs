using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;

    // zmienna do przechowywania k¹ta obrotu w osi X
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // obrót wokó³ osi Y (gracz)
        player.Rotate(Vector3.up * mouseXMove);

        // obrót wokó³ osi X (kamera)
        xRotation -= mouseYMove; // odejmujemy, ¿eby unikn¹æ efektu "mouse inverse"
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ograniczenie do -90..+90 stopni

        // ustawiamy rotacjê kamery
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
