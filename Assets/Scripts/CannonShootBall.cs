using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShootBall : MonoBehaviour
{
    public AudioClip whirr;
    public AudioClip whirrDone;
    public AudioClip cannonShot;

    public AudioClip likeThat;
    public AudioClip yourTurn;

    public AudioSource simAudio;
    AudioSource whirrSource;
    bool rising;
    bool shoot;
    bool shot;
    bool falling;
    bool wait;
    bool waiting;
    bool wait2;

    bool startWait;

    GameObject cannon;
    // Start is called before the first frame update
    void Start(){
        //Debug.Log("STARTED");
        rising = true;
        shot = false;
        cannon = this.gameObject;
        //Debug.Log(cannon.gameObject.name);
        wait = false;
        waiting = false;
        startWait = true;

        whirrSource = this.gameObject.GetComponent<AudioSource>();
        whirrSource.clip = whirr;
    }

    // Update is called once per frame
    void Update(){
        if(startWait){
            if(!waiting){
                //wait a few seconds
                //Debug.Log("WAITING TOP");
                StartCoroutine(WaitOnStart());
                waiting = true;
            }
        }


        else if(rising){
            if(!whirrSource.isPlaying){
                whirrSource.Play();
                //Debug.Log("WOULD PLAY SOUND");
            }
            cannon.transform.Translate(0, .02f, 0);
            if(cannon.transform.position.y >= 0){
                //play finished whirr sound
                whirrSource.Stop();
                whirrSource.clip = whirrDone;
                whirrSource.Play();

                rising = false;
                wait = true;
                //whirrSource.Stop();
            }
        }
        else if(wait){
            //Debug.Log("WAITING...");
            if(!waiting){
                //wait a few seconds
                StartCoroutine(WaitAfterRise(1.0f));
                waiting = true;
                //wait = false;
            }
            
        }
        else if(shoot){
            //shoot ball
            //Vector3 direction = new Vector3(20f, 20f, 40f);
            //Vector3 velocity = new Vector3(10f, 10f, 10f);
            whirrSource.clip = cannonShot;
            whirrSource.Play();

            GameObject ball = GameObject.Find("CANNONS/" + this.gameObject.name + "/CannonBall");
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            ballRB.useGravity = true;
            switch(this.gameObject.name){
                case "CannonLeftMid":
                    ballRB.AddForce(33, 72, 27);
                    break;
                case "CannonRightMid":
                    ballRB.AddForce(-33, 72, 27);
                    break;
                case "CannonMid":
                    ballRB.AddForce(0, 81, 45);
                    break;
                case "CannonLeft":
                    ballRB.AddForce(36, 81, 0);
                    break;
                case "CannonRight":
                    ballRB.AddForce(-36, 81, 0);
                    break;
                case "CannonFrontMid":
                    ballRB.AddForce(0, 63, 18);
                    break;
            }
            
            


            //Debug.Log("WOULD SHOOT BALL");
            shoot = false;
            wait2 = true;
        }
        else if(wait2){
            if(!waiting){
                //wait a few seconds
                StartCoroutine(WaitAfterShot(2.0f));
                waiting = true;
                //wait = false;
            }
        }
        else if(falling){

            if(Manager.Instance.turnNum == 2){
                simAudio.clip = likeThat;
                simAudio.Play();
            }


            //Debug.Log("WOULD START FALLING");
            if(!whirrSource.isPlaying){
                whirrSource.clip = whirr;
                whirrSource.Play();
            }
            cannon.transform.Translate(0, -.02f, 0);
            if(cannon.transform.position.y <= -2){

                whirrSource.Stop();
                whirrSource.clip = whirrDone;
                whirrSource.Play();
                falling = false;

                // re-enable

                Manager.Instance.playerTurn = true;
                Manager.Instance.computerTurn = false;
                Manager.Instance.moving = false;
                //wait = true;
                //whirrSource.Stop();
                Debug.Log("FINISHED FALLING...");

                if(Manager.Instance.firstShot){
                    Debug.Log("Lets see what you got");
                    Manager.Instance.firstShot = false;

                    simAudio.clip = yourTurn;
                    simAudio.Play();
                }


            }
        }
    }

    private IEnumerator WaitAfterRise(float time){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(time);
        // process post-yield
        wait = false;
        waiting = false;
        shoot = true;
    }

    private IEnumerator WaitAfterShot(float time){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(time);
        // process post-yield
        wait2 = false;
        waiting = false;
        falling = true;
    }

    private IEnumerator WaitOnStart(){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(7.0f);
        waiting = false;
        startWait = false;
    }
}
