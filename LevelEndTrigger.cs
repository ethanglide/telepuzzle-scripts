using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name} has entered the teleporter");

        if (other.gameObject.CompareTag("Player"))
        {
            PauseMenu.WinLevel();
            GameManager.StopLevelTheme();
        }       
    }
}
