using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera _camera;

    [SerializeField]private int _minZoom = 0;
    [SerializeField]private int _maxZoom=12000;

    private bool _moveCamera;
    void Start()
    {
        _camera=GetComponent<Camera>();
    }


    void Update()
    {
        Zoom();
        Move();
    }
    public void Zoom(){
        float mw = Input.GetAxis("Mouse ScrollWheel");
        float newY = Mathf.Clamp(transform.position.y+mw*100,_minZoom,_maxZoom);
        if(mw!=0){
               transform.position=new Vector3(transform.position.x,newY,transform.position.z);
        }
    }
    public void Move(){
        float posX = Input.GetAxis("Mouse X")*8;
        float posY = Input.GetAxis("Mouse Y")*8;
        if(Input.GetMouseButtonDown(0)){
            _moveCamera=true;
        }
        if(_moveCamera){
            _camera.transform.position-= new Vector3(posX,0,posY);
        }
        if(Input.GetMouseButtonUp(0)){
             _moveCamera=false;
        }
    }
}
