using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Data;

public class GameManager : MonoBehaviour
{
    public static event GameStates GameStart;
    public delegate void GameStates();

    [SerializeField] bool _thisLevelFirst;
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _gameCanvas;
    [SerializeField] GameObject _stopMenu;

    PassageData _passageData;
    void Start()
    {
        _passageData = PassageData.instance;
        _stopMenu.SetActive(false);
        
        if(_thisLevelFirst)
        {
            Time.timeScale = 0f;
            _gameCanvas.SetActive(false);
            _startMenu.SetActive(true);
        }
        else
        {
            _gameCanvas.SetActive(true);
        }
        
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        _gameCanvas.SetActive(true);
        GameStart();
    }
    public void NextLevelTransition()
    {
        _passageData.NextLevel();
        SceneManager.LoadScene(GameData.levels[_passageData.level]);

    }
    public void Stop()
    {
        Time.timeScale = 0f;
        _gameCanvas.SetActive(false);
        _stopMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        _stopMenu.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        _passageData.FirstLevel();
        _passageData.setData();
        SceneManager.LoadScene(GameData.levels[0]);
    }
}
