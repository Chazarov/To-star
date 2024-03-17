using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    const float _mobileSensetivity = 0.5f;

    public static event OnSwipeInput SwipeEvent;
    public static event OnSwipeInput StartSwipe;
    public delegate void OnSwipeInput(float deltaX);

    Vector2 _tapPosition;
    Vector2 _swipeDelta;

    bool _isMobile;
    float _touchMousePositionX;


    void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    void Update()
    {

        if (_isMobile)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(StartSwipe != null) StartSwipe(0f);
                _tapPosition = Input.GetTouch(0).position;
            }
            else if(Input.touchCount > 0)
            {
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
                if(SwipeEvent != null)SwipeEvent(_swipeDelta.x * _mobileSensetivity);
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(StartSwipe != null) StartSwipe(0);
                _touchMousePositionX = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                float deltaX = Input.mousePosition.x - _touchMousePositionX;
                if (SwipeEvent != null) SwipeEvent(deltaX);
            }
        }
        
    }
}
