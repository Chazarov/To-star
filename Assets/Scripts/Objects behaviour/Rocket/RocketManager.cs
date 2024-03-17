using System;
using UnityEngine;

using Settings;
public class RocketManager : MonoBehaviour
{

    [SerializeField] GameObject _gameCanvas;
    [SerializeField] GameObject _flyghtCanvas;
    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] RocketScale _rocketScale;
    [SerializeField] Rocket _rocket;
    PassageData _passageData;

    [SerializeField, Range(0, 1)] float _coefScaleRocketSizeOfProgress;
    [SerializeField, Range(0, 5)] float _coefScaleRocketForceOfProgress;

    float _coefScaleRocketFlyTimeOfProgress = SettingsConstants.coefScaleRocketFlyTimeOfProgress;


    private void Awake()
    {
        _flyghtCanvas.SetActive(false);
        _gameOverCanvas.SetActive(false);
    }

    private void OnEnable()
    {
        Rocket.RocketStartFly += StartFlight;
        Rocket.FlightIsOver += FlightIsOver;
    }

    
    void Start()
    {

        _passageData = PassageData.instance;
        if (_passageData != null)
        {
            _rocketScale.SetScale(_passageData.progress * _coefScaleRocketSizeOfProgress);
            _rocket.SetFlyTime(_passageData.progress * _coefScaleRocketFlyTimeOfProgress);
            _rocket.SetPower(_passageData.progress * _coefScaleRocketForceOfProgress);
        }
    }

    private void StartFlight(float height)
    {
        _gameCanvas.SetActive(false);
        _flyghtCanvas.SetActive(true);
    }

    private void FlightIsOver(float height)
    {
        _passageData.setScore(height);
        _flyghtCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);
        _gameOverCanvas.GetComponent<GameOverCanvas>().SetText(height);
    }

    private void OnDisable()
    {
        Rocket.RocketStartFly -= StartFlight;
        Rocket.FlightIsOver -= FlightIsOver;
    }
}
