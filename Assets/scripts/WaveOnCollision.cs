using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOnCollision : MonoBehaviour
{
    public Animator ani;
    public Waypoints wps;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        wps = GetComponent<Waypoints>();
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        Debug.Log("Started WAVE TIMER");
        yield return new WaitForSeconds(4);
        Debug.Log("Ended WAVE TIMER");
        //change speed 
        
    }

    void OnTriggerEnter (Collider other){
        Debug.Log("In Triggrt");
        if(other.gameObject.tag == "Player")
        {
          Debug.Log("animation started..."); 
          wps.speed = 0;
          ani.Play("wave");
          if (flag)
          {
            flag=false;
            StartCoroutine(ExampleCoroutine());
            flag = true;           
          }
          wps.speed = 5;
        }
    }
}
