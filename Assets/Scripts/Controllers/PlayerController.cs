using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _clickPos;
    private bool _isMove;
    private Camera _camera;
    private MouseInput _input;
    private Vector3 _destinationPoint;
    private Vector3 _currentPoint => transform.position;


    private void Start() {  
        _camera=Camera.main;
        _input=gameObject.AddComponent(typeof(MouseInput)) as MouseInput;
        _destinationPoint = _currentPoint;
    }

    private void Update() 
    {
        Move();
        ReadInput();
        MovePlayer();
    }

    public void Move()
    {
        
    }

    private void ReadInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _clickPos=_input.MousePos;
            Ray _ray = _camera.ScreenPointToRay(_clickPos);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit))
            _destinationPoint = hit.point;

            transform.LookAt(_destinationPoint);
            
        }
              
    }

    private void MovePlayer()
    {
        if (Vector3.Distance(_destinationPoint, _currentPoint) < 0.1f) return;

        var destination = new Vector3(_destinationPoint.x, _currentPoint.y,  _destinationPoint.z);
        var step = 2f * Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(_currentPoint, destination, step);
    }
}

