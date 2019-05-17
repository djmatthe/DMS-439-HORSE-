using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimCheat : MonoBehaviour
{

    public GameObject rim;
    bool moveRim = false;

    public AudioSource rimMoveSound;

    float rimEndX;
    // Start is called before the first frame update
    void Start()
    {
        rimEndX = rim.transform.position.x - 2;
        //Debug.Log("END X: " + rimEndX);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRim && rim.transform.position.x > rimEndX){
            rim.transform.Translate(0, 0, .2f);
            //Debug.Log(rim.transform.position.x);
        }
    }

    void OnTriggerEnter(Collider col){
        //Debug.Log("ENTERED");
        if(Manager.Instance.getHorseLetters() == "HORS" && !moveRim && Manager.Instance.playerTurn == true){
            //Debug.Log("MADE MOVE TRUE");
            moveRim = true;
            rimMoveSound.Play();

        }
    }
}
