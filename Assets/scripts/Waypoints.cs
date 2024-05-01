using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Waypoints : MonoBehaviour
{   
    public float speed;
    public Camera cam;
    public GameObject startObj;
    public List<GameObject> objs;
    public int currentWP;
    public string currentDl;
    public int currentP;
    public int currentSubP;
    public int maxcurrentP;
    public bool flag;
    public Animator ani;
    public Transform currentGOT;
    public TextMeshPro TMP;
    public string[] dialogue;
    public Camera mainCam;
    public InputActionReference primary;
    public DoorHandler doors;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        speed = 5;
        ani = GetComponent<Animator>();
        currentWP = 0;
        //currentDl = 0;
        currentSubP = 0;
        currentP = 0;
        flag = false;
        currentGOT = objs[currentWP].transform;
        Vector3 relPos = currentGOT.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relPos);
        //Debug.Log(Quaternion.LookRotation(relPos));
        primary.action.performed += Toggle;
        ani.Play("BasicMotions@Walk01 - Forwards");
        maxcurrentP = dialogue[currentP].Split(".").Length - 1;
        TMP.text = dialogue[currentP].Split(".")[currentSubP];

    }

    void resetDia()
    {
        currentSubP = 0;
        currentP = 0;
        maxcurrentP = dialogue[currentP].Split(".").Length - 1;
        TMP.text = dialogue[currentP].Split(".")[currentSubP];
        //Add teleport back to start using gameobj list
    }
    void Update()
    {
        //if(Vector3.Distance(transform.position, currentGOT.position) == Vector3.zero)
        //{
        //    flag = false
        //}
        Travel();
        HandleAni();
        TMP.transform.LookAt(mainCam.transform);
        TMP.transform.Rotate(new Vector3(0f,180f, 0));
        //Debug.Log(objs[curentWP].transform.position);
        //Debug.Log(objs.Count);
    }

    void HandleAni()
    {
        if (speed == 0)
        {
            ani.Play("BasicMotions@Idle01");
            flag = false;
            Vector3 camPos = cam.transform.position - transform.position;
            Debug.Log(camPos);
            transform.LookAt(camPos);
        }
        if (speed > 0 && !flag){
            flag = true;
            ani.Play("BasicMotions@Walk01 - Forwards");
        }
    }
    void Travel()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        if (Vector3.Distance(transform.position, currentGOT.position) < .5f)
        {
            speed = 0;
            //currentWP +=1;
            //currentWP = currentWP % objs.Count;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            //Debug.Log(relPos);
            //Debug.Log(currentGOT.position);
            //Debug.Log(transform.position);
            //transform.rotation = Quaternion.LookRotation(relPos);
        }
        transform.position = Vector3.MoveTowards(transform.position, currentGOT.position, step);
        //TMP.text = dialogue[curentWP];
    }
    void HanddleWaypoints()
    {
        if (currentP == 3){ 
            currentWP = 1;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relPos);
            speed = 5;
        }
        else if (currentP == 4 && doors.opened)
        {
            Debug.Log("Doors opened");
            currentWP = 2;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relPos);
            speed = 5;
        }
        else if (currentP == 5)
        {
            currentWP = 3;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relPos);
            speed = 5;
        }
        else if(currentP == 6)
        {
            currentWP = 4;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relPos);
            speed = 5;
        }
        else if(currentP == 7)
        {
            currentWP = 5;
            currentGOT = objs[currentWP].transform;
            Vector3 relPos = currentGOT.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relPos);
            speed = 5;
        }
    }

    private void Toggle(InputAction.CallbackContext context){
        Debug.Log("A Toggled");
        if (currentP == dialogue.Length - 1){
            resetDia();
            this.transform.position = new Vector3(-384.859985f,16.1529999f,80.6699982f);
            Debug.Log("Restarted");
        }
        else if (maxcurrentP == currentSubP + 1 || dialogue[currentP].Split(".").Length == 1)
        {
            Debug.Log("Test case max=current");
            currentP = currentP + 1;
            currentSubP = 0;
            maxcurrentP = dialogue[currentP].Split(".").Length - 1;
        }
        else
        {
            Debug.Log("Iterate current subP");
            currentSubP = currentSubP + 1;
        }
        HanddleWaypoints();
        TMP.text = dialogue[currentP].Split(".")[currentSubP];
    }
}
