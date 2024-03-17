using System;
using UnityEngine;

public class PlayerAnimationsBehaviour : MonoBehaviour
{
    
    [SerializeField] float _rotationSpeedOnFall;
    [SerializeField] float _fallTime;
    [SerializeField] float _fallPower;

    [SerializeField] Animator _animator;

    float _timeOnFall = 0;

    private void OnEnable()
    {
        ObjectsInterraction.StartRebound += StartRebound;
        ObjectsInterraction.OnRebound += OnRebound; ;
        ObjectsInterraction.EndRebound += EndRebound;
        GameManager.GameStart += GameStart;
    }

    private void GameStart()
    {
        _animator.SetBool("Run", true);
    }

    private void StartRebound()
    {
        _timeOnFall = _fallTime;
        _animator.SetBool("Fall", true);

    }

    private void OnRebound()
    {
        
        if(_timeOnFall - Time.deltaTime >= 0)
        {
            _timeOnFall -= Time.deltaTime;
            float y = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, _rotationSpeedOnFall * Time.deltaTime);
            transform.position -= new Vector3(0, 0, Time.deltaTime*_fallPower);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
        }
        else
        {
            _timeOnFall = 0;
        }
    }

    private void EndRebound()
    {
    }

    private void OnDisable()
    {
        ObjectsInterraction.StartRebound -= StartRebound;
        ObjectsInterraction.OnRebound -= OnRebound;
        ObjectsInterraction.EndRebound -= EndRebound;
        GameManager.GameStart -= GameStart;
    }
}
