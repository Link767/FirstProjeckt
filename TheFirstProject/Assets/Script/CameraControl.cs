using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float Malt = 1f;


    private void Update()
    {
        Malt = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        HorizontalVerticaMuvment();
        RotateMuvment();
        ZoomSpeed();
    }

    private void HorizontalVerticaMuvment()
    {
        const float Speed = 30f;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * Malt * Speed, Space.Self);
    }

    private void RotateMuvment()
    {
        const float rotateSpeed = 40f;

        float rotate = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotate = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotate = 1f;
        }

        Malt = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * Malt, Space.World);
    }

    private void ZoomSpeed()
    {
        const float zoomSpeed = 4000f;

        transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 30f), transform.position.z);
    }
}
