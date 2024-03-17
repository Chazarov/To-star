using System;
using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    public void SetText(float height)
    {
        _scoreText.text = Convert.ToString((int) height);
    }



}
