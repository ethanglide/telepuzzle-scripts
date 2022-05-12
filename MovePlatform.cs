using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 end;
    public float speed = 10f;

    // FixedUpdate is called once per fixed frame
    void Update()
    {
        if (gameObject.transform.position != end)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, end, speed * Time.deltaTime);
        }
    }
}
