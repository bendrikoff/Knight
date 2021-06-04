using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput:MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 10f;
    public float MouseX { private set; get;}
    public float MouseY { private set; get;}
    public float MoveX { private set; get;}
    public float MoveY { private set; get;}
    public float Zoom { private set; get;}

    public Vector3 MousePos{ private set; get;}
    void Update()
    {
        ListenInput();
    }
    private void ListenInput()
    {
        MouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        MousePos=Input.mousePosition;
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");
        Zoom = Input.GetAxis("Mouse ScrollWheel");
    }
}
