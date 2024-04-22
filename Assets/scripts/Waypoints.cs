using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waypoints : MonoBehaviour
{   
    public float speed;
    public List<GameObject> objs;
    public int curentWP;
    public bool flag;
    public Animator ani;
    public Transform currentGOT;
    public TextMeshProUGUI TMP;
    public string[] dialogue;
    public Camera mainCam;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        speed = 5;
        ani = GetComponent<Animator>();
        curentWP = 0;
        flag = false;
        currentGOT = objs[curentWP].transform;
        Vector3 relPos = currentGOT.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relPos);
        //Debug.Log(Quaternion.LookRotation(relPos));
        ani.Play("BasicMotions@Walk01 - Forwards");

    }
    void Update()
    {
        //if(Vector3.Distance(transform.position, currentGOT.position) == Vector3.zero)
        //{
        //    flag = false
        //}
        Travel();
        HandleAni();
        //Debug.Log(objs[curentWP].transform.position);
        //Debug.Log(objs.Count);
    }

    void HandleAni()
    {
        if (speed == 0)
        {
            ani.Play("BasicMotions@Idle01");
        }
    }
    void Travel()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        if (Vector3.Distance(transform.position, currentGOT.position) < .5f)
        {
            speed = 0;
            curentWP +=1;
            curentWP = curentWP % objs.Count;
            currentGOT = objs[curentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            //Debug.Log(relPos);
            //Debug.Log(currentGOT.position);
            //Debug.Log(transform.position);
            transform.rotation = Quaternion.LookRotation(relPos);
            StartCoroutine(ExampleCoroutine()); 
            
        }
        transform.position = Vector3.MoveTowards(transform.position, currentGOT.position, step);
        TMP.text = dialogue[curentWP];
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        //Debug.Log("Started");
        yield return new WaitForSeconds(6);
        //Debug.Log("Ended");
        ani.Play("BasicMotions@Walk01 - Forwards");
        speed=5;
        //change speed 
        
    }
}
