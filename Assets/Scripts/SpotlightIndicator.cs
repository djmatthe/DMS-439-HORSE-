using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightIndicator : MonoBehaviour
{

    Light spotlight;
    bool increase = true;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name != "GreenLight"){
            // move light to current goal
            Vector3 goalPos = Manager.Instance.currentGoalTelepoint.transform.position;
            transform.position = new Vector3(goalPos.x, transform.position.y, goalPos.z);
        }


        //get light object
        spotlight = this.gameObject.GetComponent<Light>();
        spotlight.spotAngle = 0;
    }

    // Update is called once per frame
    void Update(){
        if(increase){
            spotlight.spotAngle += .3f;
            if(spotlight.spotAngle >=30){
                increase = false;
            }
        }
        else{
            spotlight.spotAngle -= .3f;
            if(spotlight.spotAngle <= 5){
                increase = true;
            }
        }
    }
}
