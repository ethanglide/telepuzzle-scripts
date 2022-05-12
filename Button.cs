using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Material mat;
    static Color originalColor = new Color(0f, 0.6f, 0f, 1f);
    static Color activatedColor = new Color(0f, 1f, 0f, 1f);

    public Component[] activate;

    int count = 0;
    void Start()
    {
        mat.SetColor("_Color", originalColor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        mat.SetColor("_Color", activatedColor);
        count++;

        foreach (var beep in activate)
        {
            if (beep.TryGetComponent<MovePlatform>(out MovePlatform script))
            {
                script.enabled = !script.enabled;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        count--;
        if (count == 0)
        {
            mat.SetColor("_Color", originalColor);

            foreach (var beep in activate)
            {
                if (beep.TryGetComponent<MovePlatform>(out MovePlatform script))
                {
                    script.enabled = !script.enabled;
                }
            }
        }
    }
}
