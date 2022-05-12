using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    public string message;
    public bool playerOnly = true;
    public bool seeOnce = true;
    bool seen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (seeOnce == true)
        {
            if (seen == false)
            {
                if (playerOnly == true && other.CompareTag("Player"))
                {
                    Message.ShowMessage(message);
                    seen = true;
                }
                else if (playerOnly == false)
                {
                    Message.ShowMessage(message);
                    seen = true;
                }
            }
        }
        else
        {
            if (playerOnly == true && other.CompareTag("Player"))
            {
                Message.ShowMessage(message);
            }
            else if (playerOnly == false)
            {
                Message.ShowMessage(message);
            }
        }
    }
}
