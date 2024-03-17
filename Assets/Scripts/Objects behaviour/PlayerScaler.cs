using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] int _playerHeight;
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _playerBody;

    [SerializeField] float _finishDistance;

    private void Update()
    {
        _playerHeight = (int) (50 + Mathf.Abs(50 * transform.position.z / _finishDistance));
        SetScale();
    }
    public void SetScale()
    {
        _playerHeight = Mathf.Clamp(_playerHeight, 0, 100);
        float scaleCoef = (float)_playerHeight / 100;

        _playerBody.transform.localScale = new Vector3(1, 1f * scaleCoef, 1);
        _head.transform.localScale = new Vector3(0.5f + 0.5f * scaleCoef, 1, 1);
        _head.transform.localScale = new Vector3(1, 1, 0.5f + 0.5f * scaleCoef);
    }

    private void OnValidate()
    {
        SetScale();
    }
}
