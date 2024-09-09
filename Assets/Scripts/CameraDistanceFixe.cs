using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceFixe : MonoBehaviour
{

    public GameObject cibleASuivre;
    public Vector3 laDistance;

    // Update is called once per frame
    void Update()
    {
        transform.position = cibleASuivre.transform.position + laDistance;
        transform.LookAt(cibleASuivre.transform);
    }
}
