using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Explosion : MonoBehaviour
{
    void OnEnable()
    {
        Exit_Warning.onTimerZero += DestroyCharacter;
    }
    private void OnDisable()
    {
        Exit_Warning.onTimerZero -= DestroyCharacter;
    }

    private void DestroyCharacter()
    {
        GameObject player = GameObject.FindObjectOfType<Ship_Control>().gameObject;
        Destroy(player,1);
    }
}
