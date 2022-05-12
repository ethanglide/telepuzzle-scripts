using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TMP_Text text;
    public static float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            time += Time.deltaTime;

            text.text = string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(time / 60), Mathf.FloorToInt(time % 60), time % 1 * 1000);
        }
    }
}
