using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool firstCol = true;

    public AudioSource simAudio;
    public AudioClip diss1;
    public AudioClip diss2;
    public AudioClip diss3;
    public AudioClip wrongSpot;


    List<AudioClip> disses;
    public AudioClip bounceSound;
    AudioSource bounceSource;

    bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {   
        disses = new List<AudioClip> {diss1, diss2, diss3};
        bounceSource = this.gameObject.GetComponent<AudioSource>();
        bounceSource.clip = bounceSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        if(firstCol){
            firstCol = false;
            return;
        }

        if(!col.gameObject.name.Contains("Cylinder")){bounceSource.Play();}
        

        // if ball is a player ball, thouching the ground is a throw
        if(this.gameObject.name.Contains("Player") && col.gameObject.name == "Plane"){
            //Debug.Log("PLAYER THREW BALL");
            if(Manager.Instance.playerTurn){
                if(Manager.Instance.madeCurrentShot){
                    if(Manager.Instance.currentTelepoint == Manager.Instance.currentGoalTelepoint){
                        Debug.Log("PLAYER MADE SHOT");
                    }
                    else{
                        Debug.Log("PLAYER MADE SHOT BUT IN THE WRONG SPOT");
                        simAudio.clip = wrongSpot;
                        simAudio.PlayDelayed(1);
                        Manager.Instance.letterNum++;
                    }
                }
                else{
                    Manager.Instance.letterNum++;
                    if(Manager.Instance.getHorseLetters() != "HORSE"){
                        System.Random rand = new System.Random();
                        AudioClip dissNum = disses[rand.Next(0, disses.Count)];
                        // remove the diss from the list so we cant pick it again
                        disses.Remove(dissNum);

                        simAudio.clip = dissNum;
                        simAudio.PlayDelayed(1);
                    }
                }



                // can put these in a wait coroutine to allow voice acting time
                Manager.Instance.playerTurn = false;
                Manager.Instance.computerTurn = true;
                Manager.Instance.turnNum++;
                Manager.Instance.moving = false;
                Manager.Instance.madeCurrentShot = false;
            }

            StartCoroutine(Wait(this.gameObject)); 

            float yPos = 3f;
            if(spawn){
                if(this.gameObject.name.Contains("Ball1")){
                        Instantiate(this.gameObject, new Vector3(-7.5f, yPos, -6), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball2")){
                        Instantiate(this.gameObject, new Vector3(7.5f, yPos, -6), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball3")){
                        Instantiate(this.gameObject, new Vector3(0, yPos, -4), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball4")){
                        Instantiate(this.gameObject, new Vector3(6.5f, yPos, 1), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball5")){
                        Instantiate(this.gameObject, new Vector3(-6.5f, yPos, 1), new Quaternion());
                }	
                if(this.gameObject.name.Contains("Ball6")){
                        Instantiate(this.gameObject, new Vector3(8, yPos, 5.5f), new Quaternion());
                }	
                if(this.gameObject.name.Contains("Ball7")){
                        Instantiate(this.gameObject, new Vector3(1, yPos, 3), new Quaternion());
                }	
                if(this.gameObject.name.Contains("Ball8")){
                        Instantiate(this.gameObject, new Vector3(-8, yPos, 5.5f), new Quaternion());
                }							
                spawn = false;
            }
        }


        // if ball is a cannon ball, delete it after it touches the ground
        if(col.gameObject.name == "Plane"){
            //Debug.Log("CANNONBALL HIT GROUND");
            StartCoroutine(Wait(this.gameObject));
        }
    }




    IEnumerator Wait(GameObject youDie){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(Fade(youDie));
    }

    IEnumerator Fade(GameObject killMe) {
        Renderer rend = killMe.GetComponent<Renderer>();
        Color start = rend.material.color;
        float duration = 1.0f;

        for (float t = 0f; t < duration; t += Time.deltaTime) {
            float normalizedTime = t/duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            rend.material.color = Color.Lerp(start, Color.clear, normalizedTime);
            yield return null;
        }
        rend.material.color = Color.clear; //without this, the value will end at something like 0.9992367
        Destroy(killMe);
    }
}