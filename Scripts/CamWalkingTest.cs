using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWalkingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = GameObject.Find("Main Camera").transform.position;

        //camera can look around
        if(!Input.GetKey(KeyCode.LeftShift)){
            if (Input.GetKey (KeyCode.LeftArrow)) {
                this.transform.Rotate (0.0f,-3.0f,0.0f);
            }
        
            if (Input.GetKey (KeyCode.RightArrow)) {
                this.transform.Rotate (0.0f,3.0f,0.0f);
            }
        
            if (Input.GetKey (KeyCode.UpArrow)) {
                if(tmp.y <= 1.3f){
                    this.transform.Translate (0.0f,0.05f,0.0f);
                }
            }
        
            if (Input.GetKey (KeyCode.DownArrow)) {
                if(tmp.y >= 0.2f){
                    this.transform.Translate (0.0f,-0.05f,0.0f);
                }
            }
        }

    }
}
