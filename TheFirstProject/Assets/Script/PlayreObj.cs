using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreObj : MonoBehaviour
{
    public LayerMask layer;

    private void Update()
    {
        MouseTracking();
    }

    private void MouseTracking()
    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject.GetComponent<PlayreObj>());
        }
    }
}
