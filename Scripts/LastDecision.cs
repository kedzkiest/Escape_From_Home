using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastDecision : MonoBehaviour
{
    public Canvas canvas;
    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled == true){
            Menu.isEventOngoing = true;
        }
    }

    public void Yes(){
        time = Menu.totalTime;
        canvas.enabled = false;
        Menu.isEventOngoing = true;
    }

    public void No(){
        canvas.enabled = false;
        Menu.isEventOngoing = false;
    }
}
