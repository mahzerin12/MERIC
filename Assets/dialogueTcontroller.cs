using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTcontroller : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 offset = new Vector3(0,180,0);
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCam.transform);
        transform.Rotate(offset);
    }
}
