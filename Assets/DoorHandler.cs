using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public Animator D1Ani;
    public Animator D2Ani;
    public bool opened;

    public 
    // Start is called before the first frame update
    void Start()
    {
        D1Ani = Door1.GetComponent<Animator>();
        D2Ani = Door2.GetComponent<Animator>();
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter (Collider other){
        Debug.Log(other.tag);
        if (!opened && (other.tag == "humanoid" || other.tag == "Player")){
            //Debug.Log("Open the Door");
            D1Ani.Play("glass door");
            D2Ani.Play("glass door");
            opened = true;
        }
        else if (opened && other.tag == "Player"){
            //Debug.Log("Close the Door");
            D1Ani.Play("glass door reverse");
            D2Ani.Play("glass door reverse");
            opened = false;
        }
    }
}
