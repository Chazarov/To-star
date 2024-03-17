using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _textCount;
    
    float _timerTime = 12;
    bool _start = false;

    private void OnEnable()
    {
        RocketTrigger.PlayerHasComeToTheRocket += StartCount;
    }

    private void Start()
    {
        _textCount.text = "";
    }

    private void StartCount()
    {
        _start = true;
    }

    
    void Update()
    {
        if(_start)
        {

            if( _timerTime <= 0 )
            {
                
                _start = false;
            }
            else if(_timerTime < 11)
            {
                if(_timerTime < 1)
                {
                    _textCount.text = "Start!!!";
                }
                else
                {
                    _textCount.text = Convert.ToString((int) _timerTime);
                }
                
            }
            _timerTime -= Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        RocketTrigger.PlayerHasComeToTheRocket -= StartCount;
    }
}
