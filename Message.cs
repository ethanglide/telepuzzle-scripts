using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    static TMP_Text text;
    static float fade;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fade += Time.deltaTime * 0.001f;

        if (text.color != Color.clear)
        {
            text.color = Color.Lerp(text.color, Color.clear, fade);
        }       
    }

    public static void ShowMessage(string message)
    {
        text.text = "Tip:\n" + message;
        text.color = new Color(0.499f, 0.981f, 0.412f, 1f);
        fade = 0f;
    }
}
