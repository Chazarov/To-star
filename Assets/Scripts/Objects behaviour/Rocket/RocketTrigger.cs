using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class RocketTrigger : MonoBehaviour
{
    public static event PlayerState PlayerHasComeToTheRocket;
    public delegate void PlayerState();


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHasComeToTheRocket();
            Destroy(other.gameObject);
        }
    }
}
