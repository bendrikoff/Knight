using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera _camera;

    [SerializeField]private int _minZoom = 0;
    [SerializeField]private int _maxZoom=12000;
    [SerializeField]private int _moveSens=100;

    private MouseInput _input;

    void Start()
    {
        _camera=GetComponent<Camera>();
        _input=gameObject.AddComponent(typeof(MouseInput)) as MouseInput;
    }


    void Update()
    {
        Zoom();
        Move();
    }
    public void Zoom(){
        float mw = _input.Zoom;
        float newY = Mathf.Clamp(transform.position.y+mw*100,_minZoom,_maxZoom);
        if(mw!=0){
               transform.position=new Vector3(transform.position.x,newY,transform.position.z);
        }
    }
    public void Move(){
        float posX = _input.MouseX;
        float posY = _input.MouseY;
        if(Input.GetMouseButton(0)){
            _camera.transform.position-= new Vector3(posX*_moveSens,0,posY*_moveSens);
        }

    }
}
