using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IconScript : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 10;
    protected float __rotate = 0;
    void Update()
    {
        float rotateK = Mathf.Clamp(Mathf.Sin(((transform.eulerAngles.y / 360) * Mathf.PI)), 0.1f, 1);
        __rotate = 1 * rotateK * _rotateSpeed;


        transform.Rotate(0, __rotate * Time.deltaTime, 0);
    }
}
