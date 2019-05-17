using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBall : MonoBehaviour
{

    bool spawn = true;
    public AudioSource bounceSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){

        if(!col.gameObject.name.Contains("Cylinder")){bounceSource.Play();}
        

        // if ball is a player ball, thouching the ground is a throw
        if(col.gameObject.name == "Ground"){
            //Debug.Log("PLAYER THREW BALL");
            Manager.Instance.madeFirstTutorialShot = true;
            StartCoroutine(Wait(this.gameObject)); 

            float yPos = 3f;
            if(spawn){
                if(this.gameObject.name.Contains("Ball1")){
                    Instantiate(this.gameObject, new Vector3(0, yPos, -1), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball2")){
                    Instantiate(this.gameObject, new Vector3(4.25f, yPos, 7.25f), new Quaternion());
                }
                if(this.gameObject.name.Contains("Ball3")){
                    Instantiate(this.gameObject, new Vector3(4.25f, yPos, -7.25f), new Quaternion());
                }					
                spawn = false;
            }
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
