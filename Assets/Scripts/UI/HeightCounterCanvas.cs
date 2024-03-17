using Settings;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeightCounterCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _heightCountText;
    [SerializeField] Image _progressBar;

    float _progressImageSize;
    float _coefSizeOnTime = SettingsConstants.coefScaleRocketFlyTimeOfProgress;

    PassageData _passageData;

    private void Start()
    {
        _passageData = PassageData.instance;
        _progressImageSize = _passageData.progress;
        _progressBar.rectTransform.sizeDelta = new Vector3(_progressImageSize, _progressBar.rectTransform.sizeDelta.y);
    }
    private void OnEnable()
    {
        Rocket.RocketInFlight += SetHeight;
    }


    private void SetHeight(float height)
    {
        _heightCountText.text = Convert.ToString(height) + "m";
        if(_progressImageSize - Time.deltaTime / _coefSizeOnTime > 0)
        {
            _progressImageSize -= Time.deltaTime / _coefSizeOnTime;
            _progressBar.rectTransform.sizeDelta = new Vector3(_progressImageSize, _progressBar.rectTransform.sizeDelta.y);
        }
        else
        {
            _progressBar.rectTransform.sizeDelta = new Vector3(0, _progressBar.rectTransform.sizeDelta.y);
        }
        

    }

    

    private void OnDisable()
    {
        Rocket.RocketInFlight -= SetHeight;
    }
}
