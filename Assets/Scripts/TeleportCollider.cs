using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c){
        if(c.gameObject.tag == "TPP"){
            Manager.Instance.currentTelepoint = c.gameObject;
            Debug.Log("TELEPORTED TO " + c.gameObject.name.Replace("Teleport",""));
        }

        //if(){}
    }
}
