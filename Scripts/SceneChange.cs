using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public static bool is2nd = false;
    public static bool isRadioChecked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToMain(){
        SceneManager.LoadScene("Main");
    }

    public void ChangeToTitle(){
        SceneManager.LoadScene("Title");
        Result.openResultCanvas = false;
    }

    public void gameExit(){
        // Unity Editor
        // UnityEditor.EditorApplication.isPlaying = false;

        //Unity standalone
        UnityEngine.Application.Quit();
    }

    public void countRound(){
        is2nd = true;
    }

    public void stopRadio(){
        ClickTest.isRadioPlaying = false;
    }

    public void checkedRadio(){
        isRadioChecked = true;
    }
}
