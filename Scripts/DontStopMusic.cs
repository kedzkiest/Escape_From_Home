using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopMusic : MonoBehaviour
{
    public AudioClip normalBGM;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);

        if(SceneChange.is2nd == false){
            audioSource.Play();
        }
        else{
            if(SceneChange.isRadioChecked == true){
                audioSource.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ClickTest.isRadioPlaying == true){
            audioSource.Stop();
        }
    }

    public void resetRadioState(){
        SceneChange.isRadioChecked = false;
    }
}
