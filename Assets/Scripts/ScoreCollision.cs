using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("MADE THE BASKET");
        if(col.gameObject.name.Contains("Player")){
            Manager.Instance.madeCurrentShot = true;
        }
    }
}
