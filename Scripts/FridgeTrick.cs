using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeTrick : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    public Text text_left;
    public Text text_middle;
    public Text text_right;

    public static bool cannotSolveTrick_Fridge = false;
    public static bool missTrick_Fridge = false;
    public static bool solvedTrick_Fridge = false;

    public static bool closeCanvas_Fridge = false;
    // Start is called before the first frame update
    void Start()
    {
        cannotSolveTrick_Fridge = false;
        missTrick_Fridge = false;
        solvedTrick_Fridge = false;
        closeCanvas_Fridge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(closeCanvas_Fridge == true){
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
        int left = int.Parse(text_left.text);
        int middle = int.Parse(text_middle.text);
        int right = int.Parse(text_right.text);

        
        if(left == 4 && middle == 7 && right == 9){
            solvedTrick_Fridge = true;
        }
        else if(left == 4 && middle == 6 && right == 9){
            cannotSolveTrick_Fridge = true;
        }
        else{
            missTrick_Fridge = true;
        }
        
    }

    public void quitSolveFridge(){
        canvas.enabled = false;
    }
}
