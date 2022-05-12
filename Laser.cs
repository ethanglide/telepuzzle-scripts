using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    float fade;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        fade += Time.deltaTime * 0.1f;

        if(lineRenderer.startColor != Color.clear && lineRenderer.endColor != Color.clear)
        {
            lineRenderer.startColor = Color.Lerp(lineRenderer.startColor, Color.clear, fade);
            lineRenderer.endColor = Color.Lerp(lineRenderer.endColor, Color.clear, fade);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }       
    }
}
