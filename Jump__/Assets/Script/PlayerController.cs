using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private CameraController cameraController;

    private void Awake()
    {
       

        cameraController = Camera.main.GetComponent<CameraController>();
    }

    

    private void LateUpdate()
    {
        cameraController.target = transform;
    }


}

