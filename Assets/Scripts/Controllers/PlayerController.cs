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

    private GameObject _targetGO;


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


        // var _startClickPos = _input.MousePos;

        if(Input.GetMouseButtonUp(0))
        {
            // print(_startClickPos);
            // print(_clickPos);

            _clickPos=_input.MousePos;
            Ray ray = _camera.ScreenPointToRay(_clickPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.gameObject.GetComponent<Squad>())
                {
                    _destinationPoint = hit.transform.position;
                }
                else
                {
                    _destinationPoint = hit.point;
                }
            }

            //transform.LookAt( new Vector3(0,_destinationPoint.y,_destinationPoint.z));
             transform.LookAt( _destinationPoint);
            
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

