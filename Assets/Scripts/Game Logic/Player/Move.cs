using System;
using UnityEngine;


public class Move : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] float _turnSpeed;

    [SerializeField] bool _go;

    [SerializeField] Transform _pathTransform;

    float _eulerY;
    float _prewSwipeDelta;

    private void OnEnable()
    {
        ObjectsInterraction.StartRebound += StartRebound;
        ObjectsInterraction.EndRebound += EndRebound;
        SwipeDetection.SwipeEvent += OnSwipe;
        SwipeDetection.StartSwipe += StartSwipe;
    }

    private void StartRebound()
    {
        _go = false;
    }

    private void EndRebound()
    {
        _go = true;
    }

    private void StartSwipe(float positionX)
    {
        _prewSwipeDelta = 0;
    }

    private void OnSwipe(float swipeDelta)
    {
        if(_go)
        {
            float rotationCoefficient = 10f;

            _eulerY -= (_prewSwipeDelta - swipeDelta) * _turnSpeed / rotationCoefficient;
            _eulerY = dontTurnAway(_eulerY);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
            _prewSwipeDelta = swipeDelta;
        }
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        if (_go)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0, transform.position.z) + transform.forward * _speed * Time.deltaTime;
            newPosition = dontRunAway(_pathTransform, newPosition);
            transform.position = newPosition;
        }
    }

    private void OnDisable()
    {
        ObjectsInterraction.StartRebound -= StartRebound;
        ObjectsInterraction.EndRebound -= EndRebound;
        SwipeDetection.SwipeEvent -= OnSwipe;
        SwipeDetection.StartSwipe -= StartSwipe;
    }

    Vector3 dontRunAway(Transform patchTransform, Vector3 newPosition)
    {
        float leftBoard = patchTransform.position.x - patchTransform.localScale.x / 2;
        float rightBoard = patchTransform.position.x + patchTransform.localScale.x / 2;

        newPosition.x = Mathf.Clamp(newPosition.x, leftBoard + 0.5f, rightBoard - 0.5f);

        return newPosition;
    }

    float dontTurnAway(float eulerY)
    {
        eulerY = Mathf.Clamp(eulerY, -70, 70);
        return eulerY;
    }

    public void Run() { _go = true; }
    public void Stay() { _go = false; }


}
