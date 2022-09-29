using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{

    void Awake() {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
     Debug.Log("Start");   
     //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     Debug.Log("Update");   
     // transform.Translate(1,0,0);   
    }
}
