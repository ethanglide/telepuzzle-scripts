using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics;

public class Shoot : MonoBehaviour
{
    GameObject storedObject;

    public Transform beamStart;
    public Material beamMaterial;
    public Material mat;
    Color originalColor = Color.gray;

    bool isButtonPressed = false;

    //MASS OF EACH OBJECTS RIGIDBODY IS HOW MUCH OF A PULL IT GETS. BIGGER OBJECTS NEED BIGGER MASSES

    // Start is called before the first frame update
    void Start()
    {
        mat.SetColor("_Color", originalColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(PauseMenu.fire1))
            {
                RaycastHit hit;
                if (Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {                                                                                
                    if (hit.collider.CompareTag("Target"))          
                    {                                               
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, 5f);

                        var obj = new GameObject();
                        LineRenderer beam = obj.AddComponent<LineRenderer>();
                        obj.AddComponent<Laser>();

                        beam.startColor = Color.green;
                        beam.endColor = Color.white;
                        beam.startWidth = 0.06f;
                        beam.endWidth = 0.05f;
                        beam.material = beamMaterial;

                        var points = new Vector3[2];
                        points[0] = beamStart.position;
                        points[1] = hit.point;

                        beam.SetPositions(points);
                        storedObject = hit.collider.gameObject;

                        mat.SetColor("_Color", storedObject.GetComponent<Renderer>().sharedMaterial.GetColor("_Color"));
                    }                                               
                    else                                            
                    {                                               
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 5f);

                        var obj = new GameObject();
                        LineRenderer beam = obj.AddComponent<LineRenderer>();
                        obj.AddComponent<Laser>();

                        beam.startColor = Color.red;
                        beam.endColor = Color.white;
                        beam.startWidth = 0.06f;
                        beam.endWidth = 0.05f;
                        beam.material = beamMaterial;

                        var points = new Vector3[2];
                        points[0] = beamStart.position;
                        points[1] = hit.point;

                        beam.SetPositions(points);
                    }
                }
            }
            if (Input.GetKeyDown(PauseMenu.fire2))
            {
                RaycastHit hit;
                if (Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    var obj = new GameObject();
                    LineRenderer beam = obj.AddComponent<LineRenderer>();
                    obj.AddComponent<Laser>();

                    if (storedObject != null && hit.collider.gameObject != storedObject)
                    {
                        beam.startColor = Color.cyan;
                        storedObject.transform.position = hit.point;

                        Debug.Log(Vector3.Distance(storedObject.transform.position, transform.position));
                        if (Vector3.Distance(storedObject.transform.position, transform.position) > 2.6f)
                        {
                            storedObject.transform.position = Vector3.MoveTowards(storedObject.transform.position, transform.position, 0.5f);
                            storedObject.transform.position += Vector3.up /* storedObject.GetComponent<Rigidbody>().mass / 2f*/;
                        }
                        else
                        {
                            storedObject.transform.position = Vector3.MoveTowards(storedObject.transform.position, transform.position, 1f);
                        }
                        
                        storedObject = null;
                        mat.SetColor("_Color", originalColor);
                    }
                    else
                    {
                        beam.startColor = Color.red;
                    }
                    
                    
                    beam.endColor = Color.white;
                    beam.startWidth = 0.06f;
                    beam.endWidth = 0.05f;
                    beam.material = beamMaterial;

                    var points = new Vector3[2];
                    points[0] = beamStart.position;
                    points[1] = hit.point;

                    beam.SetPositions(points);                   
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("firing");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
                {
                    Debug.Log("fired");
                    Debug.DrawLine(transform.position, hit.point, Color.magenta, 5f);
                    if (hit.collider.CompareTag("Button"))
                    {
                        isButtonPressed = !isButtonPressed;
                        hit.collider.GetComponent<Presser>().Activate(isButtonPressed);
                    }
                }
            }
        }        
    }
}
