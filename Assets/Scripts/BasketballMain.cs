using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballMain : MonoBehaviour
{
    List<string> positions = new List<string> {"Left", "LeftMid", "Mid", "RightMid", "Right"};

    public GameObject[] teleportObjects;
    public GameObject[] cannonObjects;
    public GameObject spotLightTemplate;
    public GameObject currentSpotlight;
    public AudioSource lightsOut;

    public AudioClip lightClick;

    public AudioSource ambiance;

    public AudioSource simAudio;

    public AudioClip laugh;

    bool inTakingTooLong = false;

    public AudioClip thereYouAre;
    public AudioClip itsYourFirstTurn;

    public AudioClip easyOne;

    public AudioClip takingLong;
    //public AudioClip diss1;
    //public AudioClip diss2;
    //public AudioClip diss3;
    //public AudioClip likeThat;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 90;
        //set starting teleport point
        foreach(GameObject tele in teleportObjects){
            if(tele.name == "TeleportMid"){
                Manager.Instance.currentTelepoint = tele;
                break;
            }
        }
        Manager.Instance.player = GameObject.FindGameObjectWithTag("Player");
        simAudio.clip = thereYouAre;
        simAudio.PlayDelayed(2);
        Debug.Log("HEY YOU STARTED, ILL GO FIRST");

        computerShot();
    }

    // Update is called once per frame
    void Update(){
        if(Manager.Instance.getHorseLetters() == "HORSE" && !Manager.Instance.switchingToZombies){

            switchToZombies();

            Manager.Instance.moving = false;
            Manager.Instance.computerTurn = false;
            Manager.Instance.playerTurn = false;
        }
        if(Manager.Instance.moving){
            //do nothing right now
        }
        else if(Manager.Instance.computerTurn){
            if(Manager.Instance.turnNum == 3 && !inTakingTooLong){
                //"THIS IS TAKING TOO LONG"
                StartCoroutine(takingTooLong());
            }
            else if(!inTakingTooLong){
                computerShot();
            }    
        }
        else if(Manager.Instance.playerTurn){
            playerShot();
        }
    }

    void computerShot(){
        Debug.Log("COMPUTER SHOT TIME");

        if(Manager.Instance.turnNum != 0){
            Destroy(currentSpotlight);
        }

        // turn off indicator light if on
        

        Manager.Instance.moving = true;
        // pick a random point to shoot the ball from
        System.Random rand = new System.Random();
        string shotPos = positions[rand.Next(0, positions.Count)];

        // if the randomly picked point is the one the player is currently at, pick a new one
        while(Manager.Instance.currentTelepoint.name == "Teleport" + shotPos){
            shotPos = positions[rand.Next(0, positions.Count)];
        }
        // remove the point from the list so we cant pick it again
        positions.Remove(shotPos);

        if(Manager.Instance.getHorseLetters() == "HORS"){
            Debug.Log("OK, HERE'S AN EASY ONE HEHE");
            simAudio.clip = easyOne;
            simAudio.PlayDelayed(.5f);
            shotPos = "FrontMid";
        }


        //find cannon corresponding to shotPos
        GameObject ballCannon = null;
        foreach(GameObject can in cannonObjects){
            if(can.name == "Cannon" + shotPos){
                ballCannon = can;
                break;
            }
        }

        //find teleport point corresponding to shotPos
        foreach(GameObject tel in teleportObjects){
            if(tel.name == "Teleport" + shotPos){
                Manager.Instance.currentGoalTelepoint = tel;
                

                //disable teleport script
                tel.GetComponent<Valve.VR.InteractionSystem.TeleportPoint>().locked = true;

                break;
            }
        }
        //Debug.Log("SET ACTIVE");
        ballCannon.SetActive(true);

        //reenable teleport point
        //telePoint.SetActive(true);
    }

    void playerShot(){
        Manager.Instance.moving = true;
        // re-enable goal teleport script
        GameObject tel = Manager.Instance.currentGoalTelepoint;
        tel.GetComponent<Valve.VR.InteractionSystem.TeleportPoint>().locked = false;
        
        Debug.Log("PLAYER SHOT TIME");

        // turn on indicator light
        currentSpotlight = Instantiate(spotLightTemplate);
        currentSpotlight.SetActive(true);

    
        //StartCoroutine(WaitTest());

        // Manager.Instance.playerTurn = false;
        // Manager.Instance.computerTurn = true;
        // Manager.Instance.turnNum++;
        // Manager.Instance.moving = false;
    }

    void switchToZombies(){
        Manager.Instance.switchingToZombies = true;
        simAudio.clip = laugh;
        simAudio.PlayDelayed(.5f);
        Debug.Log("HAHAHAHA ZOMBIES COMING");
        ambiance.Stop();
        lightsOut.Play();


        // kill lights 
        GameObject mainLight = GameObject.Find("Directional Light");
        mainLight.SetActive(false);
        Destroy(currentSpotlight);

        StartCoroutine(WaitDark());

        //SceneManager.LoadScene(1);
    }

    private IEnumerator takingTooLong(){
        inTakingTooLong = true;
        Debug.Log("THIS IS TAKING TOO LONG (PLAY VOICE ACTING)");

        simAudio.clip = takingLong;
        simAudio.PlayDelayed(.7f);

        yield return new WaitForSeconds(4.5f);

        Manager.Instance.letterNum++;
        Manager.Instance.turnNum++;


        Debug.Log("OK, THAT'S BETTER. MY TURN!");


        yield return new WaitForSeconds(2.0f);
        
        
        inTakingTooLong = false;

        //Debug.Log("WOULD HAVE CHANGED SCENE...");
        computerShot();
    }

    private IEnumerator WaitDark(){
        // process pre-yield
        yield return new WaitForSeconds(4.0f);
        lightsOut.clip = lightClick;
        lightsOut.Play();

        Debug.Log("WOULD HAVE CHANGED SCENE...");
		Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene(2);
    }

    private IEnumerator WaitTest(){
        Debug.Log("PLAYER WOULD BE SHOOTING...");
        // process pre-yield
        yield return new WaitForSeconds(5.0f);
        //Manager.Instance.moving = false;
    }
}
