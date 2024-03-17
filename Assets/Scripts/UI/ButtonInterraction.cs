using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInterraction : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

    public void hideCanvas()
    {
        _canvas.SetActive(false);
    }
}
