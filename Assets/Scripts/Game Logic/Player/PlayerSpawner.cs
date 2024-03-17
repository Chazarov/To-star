using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    PassageData _passageData;
    [SerializeField] Animator _animator;
    void Start()
    {
        _animator.SetBool("Run", true);
        _passageData = PassageData.instance;
        Vector3 lastPosition = _passageData.getLastestPosition;
        Vector3 lastRotation = _passageData.getLastRotation;
        transform.position = new Vector3(lastPosition.x, lastPosition.y, 0);
        transform.eulerAngles = lastRotation;
    }
}
