using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 cameraMove;
    public Vector3 ggMove;
    private Camera newCamera;

    void Start()
    {
        newCamera = Camera.main.GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.transform.position += ggMove;
            newCamera.transform.position += cameraMove;
        }
    }
}
