using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour
{

    [SerializeField] GameObject _knowleageIcon;
    [SerializeField] GameObject _strangthIcon;

    [SerializeField] LootType _barrierType;
    [SerializeField] bool _indestructible;
    [SerializeField] bool _fatal;

    [SerializeField] int _value;
    [SerializeField] GameObject _canvas;
    [SerializeField] TextMeshProUGUI _valueTexst;
    [SerializeField] Transform[] _blocks;

    private void Start()
    {
        _blocks = new Transform[transform.childCount];

    }

    private void OnValidate()
    {
        _valueTexst.text = _value.ToString();

        _knowleageIcon.SetActive(false);
        _strangthIcon.SetActive(false);

        if(_indestructible)
        {
            _canvas.SetActive(false);
        }
        else
        {
            _canvas.SetActive(true);
            switch (_barrierType)
            {
                case LootType.Knowledge:
                    _knowleageIcon.SetActive(true);
                    break;
                case LootType.Strength:
                    _strangthIcon.SetActive(true);
                    break;
            }
        }
        
    }

    public void DestroyBarrier()
    {
        foreach (Transform t in transform)
        {
            BarrierBlock block;
            if(t.TryGetComponent<BarrierBlock>(out block))
            {
                block.PlayDestroyEffect();
            }
        }
        Destroy(gameObject);
    }

    public bool indestructible {  get => _indestructible; set { } }
    public bool fatal { get => _fatal; set { } }
    public int value { get => _value; set { } }
    public LootType barrierType { get => _barrierType; set { }  }
    
    
}
