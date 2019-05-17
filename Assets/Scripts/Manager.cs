using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


 public class Manager : Singleton<Manager> {
     public GameObject currentTelepoint = null;
     public GameObject currentGoalTelepoint = null;
     public GameObject player = null;
     public int letterNum = 0;

     public int turnNum = 0;

     public bool playerTurn = false;
     public bool moving = false;
     public bool computerTurn = true;

     public bool madeCurrentShot = false;

     public bool switchingToZombies = false;

     public int zombieScore = 0;

     public int zombieSpawnRate = 270; //inceasing by 90 adds one second to spawn time

     public bool madeFirstTutorialShot = false;

     public bool playingSound = false;

     public bool firstShot = true;

    //  public void updateCurrentTelepoint(Vector3 telePos){
    //     GameObject[] telePoints = GameObject.FindGameObjectsWithTag("TPP");

    //     // find the teleport point the player is closest to
    //     foreach(GameObject tp in telePoints){
    //         float lowestDistance = float.MaxValue;
    //         if(Vector3.Distance(tp.transform.position, player.transform.position) < lowestDistance){
    //             currentTelepoint = tp;
    //         }
    //     }
    //  }

    public string getHorseLetters(){
        switch(letterNum){
            case 0:
                return "";
            case 1:
                return "H";
            case 2:
                return "HO";
            case 3:
                return "HOR";
            case 4:
                return "HORS";
            case 5:
                return "HORSE";
            default:
                return "";
        }
    }

    void OnDestroy(){
        //Manager.Instance = null;
    }
}


