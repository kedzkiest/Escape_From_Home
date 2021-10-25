using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making : MonoBehaviour
{
    public Canvas makingCanvas;

    public static bool openMakingCanvas = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openMakingCanvas == true){
            makingCanvas.enabled = true;
        }
    }

    public void closeMakingCanvas(){
        openMakingCanvas = false;
        makingCanvas.enabled = false;
        Result.openResultCanvas = true;
    }
}
