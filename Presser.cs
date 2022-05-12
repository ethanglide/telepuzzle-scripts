using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presser : MonoBehaviour
{
    public static Material mat;
    static Color originalColor = new Color(0f, 0.6f, 0f, 1f);
    static Color activatedColor = new Color(0f, 1f, 0f, 1f);
    public bool isOneTimeUse = true;

    public Component[] activate;

    public Transform rayStart;
    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().sharedMaterials[1];
        mat.SetColor("_Color", originalColor);
    }

    public void Activate(bool isActivated)
    {
        if (isActivated)
        {
            mat.SetColor("_Color", activatedColor);
            foreach (var beep in activate)
            {
                if (beep.TryGetComponent<MovePlatform>(out MovePlatform script))
                {
                    script.enabled = !script.enabled;
                }
                if (beep.TryGetComponent<MovePlatform2>(out MovePlatform2 script2))
                {
                    script2.enabled = !script.enabled;
                }
            }
        }
        else if (isOneTimeUse == false)
        {
            mat.SetColor("_Color", originalColor);
            foreach (var beep in activate)
            {
                if (beep.TryGetComponent<MovePlatform>(out MovePlatform script))
                {
                    script.enabled = !script.enabled;
                }
                if (beep.TryGetComponent<MovePlatform2>(out MovePlatform2 script2))
                {
                    script2.enabled = !script.enabled;
                }
            }
        }
    }
}
