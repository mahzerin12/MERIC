using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour
{
    public string[] dialogue;

    // Update is called once per frame
    void Update()
    {
        TextMeshPro TMP = GetComponent<TextMeshPro>();
        TMP.text = "Hello";
    }
}
