using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBlock : MonoBehaviour
{
    [SerializeField] GameObject _destroyEffectPrefab;

    public void PlayDestroyEffect()
    {
        Instantiate(_destroyEffectPrefab, transform.position, transform.rotation);
    }
}
