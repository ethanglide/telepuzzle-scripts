using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBack : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public float speed = 10f;
    public float waitTime = 1f;
    float wait;
    int cycle = 0;

    private void Start()
    {
        gameObject.transform.position = start;
        wait = waitTime;
    }

    // FixedUpdate is called once per fixed frame
    void Update()
    {
        Debug.Log(wait);
        if (wait > 0)
        {
            wait -= Time.deltaTime;
            return;
        }
        if (cycle == 0 && gameObject.transform.position != end)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, end, speed * Time.deltaTime);
        }
        if (cycle == 0 && gameObject.transform.position == end)
        {
            cycle = 1;
            wait = waitTime;
        }

        if (cycle == 1 && gameObject.transform.position != start)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, start, speed * Time.deltaTime);
        }
        if (cycle == 1 && gameObject.transform.position == start)
        {
            cycle = 0;
            wait = waitTime;
        }
    }
}
