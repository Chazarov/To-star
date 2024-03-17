using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SartGameEffect : MonoBehaviour
{
    [SerializeField] float _movingSpeed;
    [SerializeField] float _finalPositionY;
    [SerializeField] GameObject _camera;

    bool _EffectBegun = false;


    private void OnEnable()
    {
        GameManager.GameStart += GameStart;
    }

    private void GameStart()
    {
        _EffectBegun = true;
    }

    private void Update()
    {
        if (_EffectBegun)
        {
            if(_finalPositionY > _camera.transform.localPosition.y - Time.deltaTime * _movingSpeed)
            {
                _camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x, _finalPositionY, _camera.transform.localPosition.z);
                _EffectBegun = false;
            }
            else
            {
                _camera.transform.localPosition += new Vector3(0, -Time.deltaTime * _movingSpeed, 0);
            }
        }
        
    }

    private void OnDisable()
    {
        GameManager.GameStart -= GameStart;
    }


}
