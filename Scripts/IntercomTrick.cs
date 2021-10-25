using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntercomTrick : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    public Text text_right;
    public Text text_topRight;
    public Text text_topLeft;
    public Text text_left;
    public Text text_bottomLeft;
    public Text text_bottomRight;

    public static bool cannotSolveTrick_Intercom = false;
    public static bool missTrick_Intercom = false;
    public static bool solvedTrick_Intercom = false;

    public static bool closeCanvas_Intercom = false;
    // Start is called before the first frame update
    void Start()
    {
        cannotSolveTrick_Intercom = false;
        missTrick_Intercom = false;
        solvedTrick_Intercom = false;
        closeCanvas_Intercom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(closeCanvas_Intercom == true){
            canvas.enabled = false;
        }
    }

    public void updateNumber(){
        int tmp = int.Parse(text.text);
        if(tmp == 9){
            tmp = 0;
        }
        else{
            tmp++;
        }

        text.text = tmp.ToString();
    }

    public void determineNumber(){
        int right = int.Parse(text_right.text);
        int topRight = int.Parse(text_topRight.text);
        int topLeft = int.Parse(text_topLeft.text);
        int left = int.Parse(text_left.text);
        int bottomLeft = int.Parse(text_bottomLeft.text);
        int bottomRight = int.Parse(text_bottomRight.text);

        
        if(right == 5 && topRight == 2 && topLeft == 3 && left == 4 && bottomLeft == 7 && bottomRight == 0){
            solvedTrick_Intercom = true;
        }
        else if(right == 4 && topRight == 7 && topLeft == 0 && left == 5 && bottomLeft == 2 && bottomRight == 3){
            cannotSolveTrick_Intercom = true;
        }
        else{
            missTrick_Intercom = true;
        }
        
    }

    public void quitSolveIntercom(){
        canvas.enabled = false;
    }
}
