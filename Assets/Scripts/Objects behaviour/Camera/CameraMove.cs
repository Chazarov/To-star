using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
   
    [SerializeField] Transform _target1;
    [SerializeField] Transform _target2;
    Transform _currentTarget;


    private void OnEnable()
    {
        RocketTrigger.PlayerHasComeToTheRocket += ChangeTarget;
    }

    private void Start()
    {
        _currentTarget = _target1;
    }

    private void LateUpdate()
    {
        if (_currentTarget != null)
        {
            transform.position = _currentTarget.position;
        }
    }

    private void ChangeTarget()
    {
        if (_target2 != null)
        {
            _currentTarget = _target2;
        }
        
    }

    private void OnDisable()
    {
        RocketTrigger.PlayerHasComeToTheRocket -= ChangeTarget;
    }
}
