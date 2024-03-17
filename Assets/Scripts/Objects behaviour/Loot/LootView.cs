using System;
using TMPro;
using UnityEngine;


public class LootView : MonoBehaviour
{


    [SerializeField] GameObject _knowledgeIcon;
    [SerializeField] GameObject _strengthIcon;
    [SerializeField] GameObject _progressIcon;
    [SerializeField] GameObject _negativeKnowleageIcon;
    [SerializeField] GameObject _negativeStrengthIcon;

    [SerializeField] TextMeshProUGUI _valueText;

    [SerializeField] Color _positiveColor;
    [SerializeField] Color _negativeColor;

    public void setView(LootType type, int value)
    {
        _knowledgeIcon.SetActive(false);
        _strengthIcon.SetActive(false);
        _progressIcon.SetActive(false);
        _negativeKnowleageIcon.SetActive(false);
        _negativeStrengthIcon.SetActive(false);

        _valueText.text = Convert.ToString(value);

        switch (type)
        {
            case(LootType.Knowledge):
                if(value > 0)
                {
                    _valueText.color = _positiveColor;
                    _knowledgeIcon.SetActive(true);
                }
                else
                {
                    _valueText.color = _negativeColor;
                    _negativeKnowleageIcon.SetActive(true);
                }
                break;
            case(LootType.Strength):
                if(value > 0)
                {
                    _valueText.color = _positiveColor;
                    _strengthIcon.SetActive (true);
                }
                else
                {
                    _valueText.color = _negativeColor;
                    _negativeStrengthIcon.SetActive (true);
                }
                break;
            case (LootType.Progress):
                {
                    _progressIcon.SetActive (true);
                    _valueText.color = _positiveColor;
                }
                break;
        }
    }
}
