using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurveillance : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform laCibleASuivre;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(laCibleASuivre.transform);
    }
}
