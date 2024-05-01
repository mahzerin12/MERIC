using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling : MonoBehaviour
{
    Vector3 startScale;
    Vector3 scaleDown;
    Vector3 scaleUp;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startScale = this.transform.localScale;
        Vector3 scaleDown = new Vector3(0.01f,0.01f,0.01f); 
        Vector3 scaleUp = new Vector3(100f,100f,100f);       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScaleDown(){
        Debug.Log("scaling Down");
        Debug.Log(this.transform.localScale* 1000) ;
        this.transform.localScale = new Vector3(0.00151911306f,0.00151911306f,0.00151911306f);
        Debug.Log(this.transform.localScale* 1000);
    }

    public void updateScaleUp(){
        this.transform.localScale = startScale;
    }
}
