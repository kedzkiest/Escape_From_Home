using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTest : MonoBehaviour
{
    public Canvas canvas;
    public Canvas FridgeCanvas;
    public Canvas IntercomCanvas;
    public Canvas LastDecisionCanvas;
    public Text text;
    public Material cleanedIntercom;
    public AudioClip normalBGM;
    public AudioClip radioBGM;
    private AudioSource audioSource;

    int tutorial_flag = 0;
    GameObject mainCamera;

    bool inLiving = true;
    bool openBedroomFirstTime = true;
    public static bool BedroomKey = false;

    bool checkFridgeFirstTime = true;
    bool fridgeHint = false;
    static bool fridgeSolved = false;
    
    public static bool BathroomKey = false;
    bool openBathroomFirstTime = true;

    bool inBathroom = false;
    bool inLaundryroom = false;
    public static bool Soap = false;
    bool cleanIntercomFirstTime = true;
    bool solveIntercomFirstTime = true;
    bool intercomHint = false;
    static bool intercomSolved = false;
    public static bool EntranceKey = false;

    public static bool isRadioPlaying = false;
    bool isCurtainOpen = false;

    bool lastDecision = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorial_flag = 0;
        inLiving = true;
        openBedroomFirstTime = true;
        BedroomKey = false;
        checkFridgeFirstTime = true;
        fridgeHint = false;
        fridgeSolved = false;
        BathroomKey = false;
        openBathroomFirstTime = true;
        inBathroom = false;
        inLaundryroom = false;
        Soap = false;
        cleanIntercomFirstTime = true;
        solveIntercomFirstTime = true;
        intercomHint = false;
        intercomSolved = false;
        EntranceKey = false;
        isRadioPlaying = false;
        isCurtainOpen = false;
        lastDecision = false;



        canvas.enabled = true;
        tutorial_flag = 1;
        mainCamera = Camera.main.gameObject;
        text.text = "-操作1-\n方向キー左右で視点回転　方向キー上下で高さ調節";
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled == true){
            Menu.isEventOngoing = true;
            if(Input.GetMouseButtonDown(0)){
                if(tutorial_flag == 1){
                    text.text = "-操作2-\nクリックでオブジェクトを調べる";
                    tutorial_flag = 2;
                }
                else if(tutorial_flag == 2){
                    text.text = "-操作3-\nTabキーでメニューを開く";
                    tutorial_flag = 0;
                }
                else{
                    canvas.enabled = false;
                    Menu.isEventOngoing = false;
                }
            }
        }

        if(FridgeTrick.cannotSolveTrick_Fridge == true){
            giveFridgeHint();
        }

        if(FridgeTrick.missTrick_Fridge == true){
            tellYouMadeItWrong_Fridge();
        }

        if(FridgeTrick.solvedTrick_Fridge == true){
            tellYouMadeItWell_Fridge();
        }

        if(IntercomTrick.cannotSolveTrick_Intercom == true){
            giveIntercomHint();
        }

        if(IntercomTrick.missTrick_Intercom == true){
            tellYouMadeItWrong_Intercom();
        }

        if(IntercomTrick.solvedTrick_Intercom == true){
            tellYouMadeItWell_Intercom();
        }
        
    }

    public void onClickCone1(){
        Vector3 tmp = GameObject.Find("pos1").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 1;
        ControlCones.flag1 = true;
    }

    public void onClickCone2(){
        Vector3 tmp = GameObject.Find("pos2").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 2;
        ControlCones.flag2 = true;
    }

    public void onClickCone3(){
        Vector3 tmp = GameObject.Find("pos3").transform.position;
        mainCamera.transform.position = tmp;
        ControlCones.camera_flag = 3;
        ControlCones.flag3 = true;
    }

    //objects
    public void onClickEntranceDoor(){
        if(EntranceKey == false){
            canvas.enabled = true;
            text.text = "玄関のドア。内鍵はかかっていないのに開かない。";
        }
        else{
            if(lastDecision == false){
                canvas.enabled = true;
                text.text = "どうやら玄関のロックが解除されたらしい。";
                lastDecision = true;
            }
            else{
                LastDecisionCanvas.enabled = true;
            }
        }
    }

    public void onClickGardenDoor(){
        canvas.enabled = true;
        text.text = "庭に続くドア。内鍵はかかっていないのに開かない。";
    }

    public void onClickBedDoor(){
        if(BedroomKey == false){
            canvas.enabled = true;
            text.text = "この先は寝室だが、鍵がかかっているようだ。";
        }
        else{
            if(openBedroomFirstTime == true){
                canvas.enabled = true;
                text.text = "寝室の鍵を開けた。";
                openBedroomFirstTime = false;
            }
            else{
                if(inLiving == true){
                    Vector3 tmp = GameObject.Find("pos4").transform.position;
                    mainCamera.transform.position = tmp;
                    inLiving = false;
                }
                else{
                    Vector3 tmp = GameObject.Find("pos1").transform.position;
                    mainCamera.transform.position = tmp;
                    ControlCones.camera_flag = 1;
                    ControlCones.flag1 = true;
                    inLiving = true;
                }
            }
        }
    }

    public void onClickBathDoor(){
        if(BathroomKey == false){
            canvas.enabled = true;
            text.text = "この先は脱衣所だが、鍵がかかっているようだ。";
        }
        else{
            if(openBathroomFirstTime == true){
                canvas.enabled = true;
                text.text = "脱衣所の鍵を開けた。";
                openBathroomFirstTime = false;
            }
            else{
                if(inLiving == true){
                    Vector3 tmp = GameObject.Find("pos5").transform.position;
                    mainCamera.transform.position = tmp;
                    inLiving = false;
                }
                else{
                    Vector3 tmp = GameObject.Find("pos2").transform.position;
                    mainCamera.transform.position = tmp;
                    ControlCones.camera_flag = 2;
                    ControlCones.flag2 = true;
                    inLiving = true;
                }
            }
        }
    }

    public void onClickBathroomDoor(){
        if(inBathroom == false){
            Vector3 tmp = GameObject.Find("pos6").transform.position;
            mainCamera.transform.position = tmp;
            inBathroom = true;
        }
        else{
            Vector3 tmp = GameObject.Find("pos5").transform.position;
            mainCamera.transform.position = tmp;
            inBathroom = false;
        }
    }

    public void onClickLaundryDoor(){
        if(inLaundryroom == false){
            Vector3 tmp = GameObject.Find("pos7").transform.position;
            mainCamera.transform.position = tmp;
            inLaundryroom = true;
        }
        else{
            Vector3 tmp = GameObject.Find("pos5").transform.position;
            mainCamera.transform.position = tmp;
            inLaundryroom = false;
        }
    }

    public void onClickIntercom(){
        if(Soap == false){
            canvas.enabled = true;
            text.text = "恐らくインターフォンだが、ひどく汚れている。";
        }
        else{
            if(cleanIntercomFirstTime == true){
                canvas.enabled = true;
                text.text = "インターフォンを洗剤できれいにした。";
                GameObject intercom = GameObject.Find("Video intercomV1");
                intercom.GetComponent<Renderer>().material = cleanedIntercom;
                cleanIntercomFirstTime = false;
            }
            else{
                if(intercomSolved == false){
                    if(solveIntercomFirstTime == true){
                        canvas.enabled = true;
                        text.text = "インターフォンだ。いくつかボタンがついている。";
                        IntercomCanvas.enabled = true;
                        solveIntercomFirstTime = false;
                    }
                    else{
                        IntercomCanvas.enabled = true;
                    }

                }else{
                    canvas.enabled = true;
                    text.text = "下手にいじってもう一度ロックされたら困る。";
                }
            }
        }
    }

    public void giveIntercomHint(){
        IntercomTrick.cannotSolveTrick_Intercom = false;
        canvas.enabled = true;
        if(intercomHint == false){
            text.text = "これで合っているはずだが・・。";
            intercomHint = true;
        }
        else{
            text.text = "上のNはNorth(北)？あるいはNegitoroかもしれない。";
        }
    }

    public void tellYouMadeItWrong_Intercom(){
        IntercomTrick.missTrick_Intercom = false;
        canvas.enabled = true;
        text.text = "番号が違うようだ。";
    }

    public void tellYouMadeItWell_Intercom(){
        intercomSolved = true;
        IntercomTrick.solvedTrick_Intercom = false;
        canvas.enabled = true;
        if(intercomSolved == true){
            text.text = "どこかのドアのロックが解除されたようだ。";
            EntranceKey = true;
            IntercomTrick.closeCanvas_Intercom = true;
        }
    }

    public void onClickShoes(){
        canvas.enabled = true;
        text.text = "自分の靴がある。";
    }
    
    public void onClickWatch(){
        canvas.enabled = true;
        text.text = "時計がある。よくズレる上に読みづらくて当てにならない。";
    }

    public void onClickFridge(){
        if(fridgeSolved == false){
            if(checkFridgeFirstTime == true){
                canvas.enabled = true;
                text.text = "冷蔵庫だ。よく見るといくつかの絵とボタンがついている。";
                FridgeCanvas.enabled = true;
                checkFridgeFirstTime = false;
            }
            else{
                FridgeCanvas.enabled = true;
            }

        }else{
            canvas.enabled = true;
            text.text = "鍵以外何も入っていなかった。";
        }
    }

    public void giveFridgeHint(){
        FridgeTrick.cannotSolveTrick_Fridge = false;
        canvas.enabled = true;
        if(fridgeHint == false){
            text.text = "これで合っているはずだが・・。";
            fridgeHint = true;
        }
        else{
            text.text = "そういえば、浴室にも椅子が１つあったことを思い出した。";
        }
    }

    public void tellYouMadeItWrong_Fridge(){
        FridgeTrick.missTrick_Fridge = false;
        canvas.enabled = true;
        text.text = "番号が違うようだ。";
    }

    public void tellYouMadeItWell_Fridge(){
        fridgeSolved = true;
        FridgeTrick.solvedTrick_Fridge = false;
        canvas.enabled = true;
        if(fridgeSolved == true){
            text.text = "冷蔵庫が開いた。中から脱衣所の鍵を手に入れた。";
            BathroomKey = true;
            FridgeTrick.closeCanvas_Fridge = true;
        }
    }

    public void onClickPlant(){
        canvas.enabled = true;
        text.text = "観葉植物がある。";
    }

    public void onClickMadoriPic(){
        canvas.enabled = true;
        text.text = "家の間取り図のような絵だ。";        
    }

    public void onClickGrapefruit(){
        canvas.enabled = true;
        text.text = "よく見ると、これは絵ではなくグレープフルーツだ。";
    }

    public void onClickScenaryPic(){
        canvas.enabled = true;
        text.text = "風景画がある。";
    }

    public void onClickGraphPic(){
        canvas.enabled = true;
        text.text = "xy平面のような絵だ。";
    }

    public void onClickAbstractPic(){
        canvas.enabled = true;
        text.text = "抽象的な絵だ。何を表しているのかよく分からない。";
    }

    public void onClickTomatoPic(){
        canvas.enabled = true;
        text.text = "これは本物のトマト・・・ではなくてトマトの絵だ。";
    }

    public void onClickEggplantPic(){
        canvas.enabled = true;
        text.text = "これはオーバージーン・・・エッグプラントではない。";
    }

    public void onClickBreakoutPic(){
        canvas.enabled = true;
        text.text = "ブロック崩しの絵だろうか？よくできている。";
    }

    public void onClickLivePic(){
        canvas.enabled = true;
        text.text = "ライブの絵だろうか？手前にペンライトが見える。";
    }

    public void onClickKPic(){
        canvas.enabled = true;
        text.text = "力強い意思がこもった絵だ。";
    }

    public void onClickWindows(){
        canvas.enabled = true;
        text.text = "窓は閉まってる。";
    }

    public void onClickCurtain(){
        if(isCurtainOpen == false){
            canvas.enabled = true;
            text.text = "カーテンを開けた。";
            isCurtainOpen = true;
        }
    }

    public void onClickRadio(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if(isRadioPlaying == false){
            canvas.enabled = true;
            text.text = "電源をオンにした。";
            audioSource.volume = 0.2f;
            audioSource.clip = radioBGM;
            
            audioSource.Play();
            isRadioPlaying = true;
        }
        else{
            canvas.enabled = true;
            text.text = "電源をオフにした。";
            audioSource.volume = 1.0f;
            audioSource.clip = normalBGM;
            audioSource.Play();
            isRadioPlaying = false;
        }
    }

    public void onClickHeadboard(){
        canvas.enabled = true;
        text.text = "中に「北」と書かれたメモが入っている。\n普段あまり方角を意識しないから、なんだか新鮮だ。";
    }

    
    //items
    public void onClickBedroomKey(){
        canvas.enabled = true;
        text.text = "寝室の鍵を手に入れた。";
        BedroomKey = true;
        GameObject.Find("BedroomKey").transform.localScale = new Vector3(0, 0, 0);
    }

    public void onClickDetergent(){
        canvas.enabled = true;
        text.text = "洗剤を手に入れた。";
        Soap = true;
    }

}
