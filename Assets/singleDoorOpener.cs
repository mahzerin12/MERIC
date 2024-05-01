using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleDoorOpener : MonoBehaviour
{
    public GameObject Door;
    public Animator ani;
    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        ani = Door.GetComponent<Animator>();
    }

    // Update is called once per frame
     void OnTriggerEnter (Collider other)
     {
        if (!opened){
            ani.Play("door 3 reverse");
            opened = true;
        }
    }
}
