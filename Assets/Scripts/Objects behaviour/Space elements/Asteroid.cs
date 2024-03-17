using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject _asteroid;
    [SerializeField] Transform _firstPosition;
    [SerializeField] Transform _secondPosition;

    [SerializeField] float _speed;

    void Update()
    {
        Vector3 nextPosition = _secondPosition.position - _asteroid.transform.position;
        if(nextPosition.magnitude < 1)
        {
            _asteroid.SetActive(false);
            _asteroid.transform.position = _firstPosition.position;
            _asteroid.SetActive(true);
        }
        else
        {
            nextPosition = nextPosition.normalized * _speed * Time.deltaTime;
            _asteroid.transform.position += nextPosition;

        }
        
    }
}
