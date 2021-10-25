using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Canvas resultCanvas;
    public Text time_text;
    public Text score_text;
    string score;
    public static bool openResultCanvas = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openResultCanvas == true){
            resultCanvas.enabled = true;
        }

        time_text.text = "脱出にかかった時間\n" + string.Format("{0:f3}", LastDecision.time) + "秒";

        if(ClickTest.BedroomKey == true && ClickTest.BathroomKey == true && ClickTest.Soap == true){
            if(LastDecision.time <= 37){
                score = "SS";
            }
            else if(LastDecision.time <= 45){
                score = "S+";
            }
            else if(LastDecision.time <= 60){
                score = "S";
            }
            else if(LastDecision.time <= 80){
                score = "A+";;
            }
            else if(LastDecision.time <= 110){
                score = "A";
            }
            else if(LastDecision.time <= 140){
                score = "B+";
            }
            else if(LastDecision.time <= 170){
                score = "B";
            }
            else if(LastDecision.time <= 200){
                score = "C+";
            }
            else if(LastDecision.time <= 240){
                score = "C";
            }
            else if(LastDecision.time <= 280){
                score = "D+";
            }
            else if(LastDecision.time <= 320){
                score = "D";
            }
            else if(LastDecision.time <= 360){
                score = "E+";
            }
            else if(LastDecision.time <= 400){
                score = "E";
            }
            else if(LastDecision.time <= 450){
                score = "F+";
            }
            else if(LastDecision.time <= 500){
                score = "F";
            }
            else if(LastDecision.time <= 550){
                score = "G+";
            }
            else{
                score = "G";
            }   
        }
        else{
            score = "G";
        }
        
        score_text.text = "評価：" + score;
        
    }

    public void openMakingCanvas(){
        openResultCanvas = false;
        resultCanvas.enabled = false;
        Making.openMakingCanvas = true;
    }
    
}
