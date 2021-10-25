using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeoutPanel : MonoBehaviour
{
    public Canvas canvas;
    Image img;
    int flag = 0;
    float alpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        panelFadein();
    }

    public void panelFadeout(){
        canvas.enabled = true;
        alpha = 0;
        flag = 1;
    }

    public void panelFadein(){
        canvas.enabled = true;
        alpha = 1;
        flag = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == 1){
            alpha += 0.02f;
            img.color = new Color(0f, 0f, 0f, alpha);
            if(alpha >= 1f){
                flag = 0;
                canvas.enabled = false;
                Result.openResultCanvas = true;
            }
        }

        if(flag == 2){
            alpha -= 0.01f;
            img.color = new Color(0f, 0f, 0f, alpha);
            if(alpha <= 0){
                flag = 0;
                canvas.enabled = false;
            }
        }
    }
}
