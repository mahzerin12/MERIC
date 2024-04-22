using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGo : MonoBehaviour
{
    public int rate = 100;
    public int frame = 0;
    public GameObject Cam;
    public GameObject GogoObj;
    public GameObject RightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(Cam.transform.position, this.transform.position);
        //Debug.Log(Cam.transform.position - this.transform.position);
        if (frame % rate == 0){
            Debug.Log("Righthand Pos:" + this.transform.position);
        }
        if (Mathf.Abs(dist) > .49){
            //Debug.Log("EXTEND");
            //Debug.Log(Mathf.Abs(Cam.transform.position.z - this.transform.position.z));
            var z = SetZ(1.5f);
            Debug.Log("Righthand pos:" + this.transform.localPosition);
            var pos = this.transform.localPosition;
            pos.z = Mathf.Abs(pos.z * z) ;
            //pos.z = this.transform.localPosition.z * z * (float)3;

            Debug.Log("new Pos"+pos);
            GogoObj.transform.localPosition = pos;
            Debug.Log("gogo local" + GogoObj.transform.localPosition);
            //Debug.Log("gogo global" + GogoObj.transform.position);
        }
        else{
            GogoObj.transform.localPosition = RightHand.transform.localPosition;
        }
        //this.transform.position = SetZ(this.transform.position, (float)1.0);
        frame++;
    }

    float SetZ(float z)
    {
       // Debug.Log("CHECK INITIAL: " + (Cam.transform.position - vect));
        var dist = Vector3.Distance(Cam.transform.position, this.transform.position);
        //vect = vect + z*Mathf.Sqrt(Cam.transform.position - this.transform.position);
        var me = dist + z*Mathf.Pow(dist, 2.0f);
        Debug.Log(me);
        return me;
    }
}
