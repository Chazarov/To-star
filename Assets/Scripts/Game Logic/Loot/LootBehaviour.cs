using System;
using UnityEngine;

public enum LootType
{
    Knowledge,
    Strength,
    Progress
}

[RequireComponent(typeof(LootView))]

public class LootBehaviour : MonoBehaviour
{
    [SerializeField] LootType _type;
    [SerializeField] int _value;

    [SerializeField] LootView _lootView;

    PassageData passageData;

    private void Start()
    {
        passageData = PassageData.instance;
        _lootView = GetComponent<LootView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch(_type)
            {
                case(LootType.Knowledge):
                    passageData.setKnowleage(_value);
                    break;
                case(LootType.Strength):
                    passageData.setStranght(_value);
                    break;
                case(LootType.Progress):
                    passageData.setProgress(_value);
                    break;
            }
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        if(_type == LootType.Progress)
        {
            _value = _value > 0 ? _value : 0;
        }
        _lootView.setView(_type, _value);
        
    }

   

    public LootType getLootType { get { return _type; } set { } }
}




