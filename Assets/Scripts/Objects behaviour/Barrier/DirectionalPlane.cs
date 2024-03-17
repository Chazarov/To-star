using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPlane : MonoBehaviour 
{
    public static DirectionalPlane Instance;

    private void Awake()
    {
        Instance = this;
    }
}
