using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Data;

public class NextLevelTransitionTrigger : MonoBehaviour
{

    [SerializeField] PassageData _passageData;

    private void Start()
    {
        _passageData = PassageData.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            _passageData.NextLevel();
            _passageData.setLastestPosition(other.transform.position, other.transform.eulerAngles);
            SceneManager.LoadScene(GameData.levels[_passageData.level]);
        }
    }
}
