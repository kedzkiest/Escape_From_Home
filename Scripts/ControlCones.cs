using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCones : MonoBehaviour
{
    public static int camera_flag;
    Vector3 cone1, cone2, cone3;
    public static bool flag1, flag2, flag3;

    // Start is called before the first frame update
    void Start()
    {
        cone1 = GameObject.Find("pos1_cone").transform.localScale;
        cone2 = GameObject.Find("pos2_cone").transform.localScale;
        cone3 = GameObject.Find("pos3_cone").transform.localScale;
        camera_flag = 1;
        flag1 = true;
        flag2 = false;
        flag3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(camera_flag == 1){
            if(flag1 == true){
                cone1 = new Vector3(0, 0, 0);
                GameObject.Find("pos1_cone").transform.localScale = cone1;

                cone2 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos2_cone").transform.localScale = cone2;

                cone3 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos3_cone").transform.localScale = cone3;

                flag1 = false;
            }
        }

        if(camera_flag == 2){
            if(flag2 == true){
                cone1 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos1_cone").transform.localScale = cone1;

                cone2 = new Vector3(0, 0, 0);
                GameObject.Find("pos2_cone").transform.localScale = cone2;

                cone3 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos3_cone").transform.localScale = cone3;

                flag2 = false;
            }
        }

        if(camera_flag == 3){
            if(flag3 == true){
                cone1 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos1_cone").transform.localScale = cone1;

                cone2 = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Find("pos2_cone").transform.localScale = cone2;

                cone3 = new Vector3(0, 0, 0);
                GameObject.Find("pos3_cone").transform.localScale = cone3;

                flag3 = false;
            }
        }
    }
}
