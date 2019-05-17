using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieScore : MonoBehaviour
{
    TextMesh board;
    string currentScore = "00";

    public AudioSource point;
    // Start is called before the first frame update
    void Start()
    {
        board = this.gameObject.GetComponent<TextMesh>();
        currentScore = board.text = "00";
    
    }

    // Update is called once per frame
    void Update()
    {     
        if(Int32.Parse(currentScore) != Manager.Instance.zombieScore){
            //currentScore = Manager.Instance.zombieScore.ToString();
            if(Manager.Instance.zombieScore < 10){
                currentScore = board.text = "0" + Manager.Instance.zombieScore.ToString();
            }
            else{
                currentScore = board.text = Manager.Instance.zombieScore.ToString();
            }

            //play a sound on getting a point
            if(!this.gameObject.name.Contains("Glow")){
                Debug.Log("PLAYING SOUND");
                point.Play();
            }
        }  
    }
}