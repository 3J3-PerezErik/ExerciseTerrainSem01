using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3emeP : MonoBehaviour
{

    public GameObject laCibleASuivre;

    public Vector3 distanceCamera;

    public float ValeurTransition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posFinale = laCibleASuivre.transform.TransformPoint(distanceCamera);
        transform.position = Vector3.Lerp(transform.position, posFinale, ValeurTransition);
        
        transform.LookAt(laCibleASuivre.transform);
    }
}
