using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveStart : MonoBehaviour
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
		if(col.gameObject.tag == "Player"){
			SceneManager.LoadScene(0);
			
		}
		Debug.Log("youre here");
	}
}
