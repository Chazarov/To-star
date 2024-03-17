using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _strangthText;
    [SerializeField] TextMeshProUGUI _knowleageText;

    [SerializeField] Image _strangthBar;
    [SerializeField] Image _knowleageBar;
    [SerializeField] Image _progressBar;

    int _defaultIndent = 2;
    float _coefStableImages = 0.5f;

    PassageData _passageData;

    private void Start()
    {
        _passageData = PassageData.instance;
        setViev();
    }
    private void OnEnable()
    {
        PassageData.SetPassageData += SetPassageData;
    }

    private void SetPassageData()
    {
        setViev();
    }

    private void OnDisable()
    {
        PassageData.SetPassageData -= SetPassageData;
    }

    private void setViev()
    {
        _strangthText.text = _passageData.strangth.ToString();
        _knowleageText.text = _passageData.knowledge.ToString();
        _strangthBar.rectTransform.sizeDelta = new Vector3(_passageData.strangth *_coefStableImages  + _defaultIndent, _strangthBar.rectTransform.sizeDelta.y);
        _knowleageBar.rectTransform.sizeDelta = new Vector3(_passageData.knowledge*_coefStableImages + _defaultIndent, _knowleageBar.rectTransform.sizeDelta.y);
        _progressBar.rectTransform.sizeDelta = new Vector3(_passageData.progress + _defaultIndent, _progressBar.rectTransform.sizeDelta.y);
    }
}
