using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour: IMoveable
{    
    private Vector3 _clickPos;

    private bool _isMove;

    private GameObject _playerGO;



    public PlayerMoveBehaviour(GameObject player){
        _playerGO=player;

    }

    public void Move(){
        if(Input.GetMouseButtonDown(0)){
            _clickPos=Input.mousePosition;
            Debug.Log(_clickPos);
            _isMove=true;
        }
        if(_isMove){
            Vector3 _worldVector = _camera.WorldToScreenPoint(_clickPos);
            _playerGO.transform.Translate(_worldVector);
        }
    }
}
