using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour{
	
	public AudioSource zSound;
	
    // Start is called before the first frame update
    void Start()
    {
        zSound = GetComponent<AudioSource>();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter (Collider col){
		Debug.Log("hit");
		if(col.gameObject.tag == "ZombieWall"){
			zSound.Play();
		
		}	
	}
	
}
