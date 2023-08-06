using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos = new Vector3(0, 15, -10);
    Camera MainCamera;

    private void Start()
    {
        MainCamera = GetComponent<Camera>();
        MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.transform.position + pos;
    }
}
