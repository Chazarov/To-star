using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectScript : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] GameObject _colissionPlane;
    void Start()
    {
        _particleSystem.Stop();
        _colissionPlane = DirectionalPlane.Instance.gameObject;
        _particleSystem.collision.AddPlane(_colissionPlane.transform);
        _particleSystem.Play();
    }
    
}
