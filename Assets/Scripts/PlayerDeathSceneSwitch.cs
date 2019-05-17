using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathSceneSwitch : MonoBehaviour
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
		if(col.gameObject.tag == "Zombie"){
			Debug.Log("Ow");
			SceneManager.LoadScene(3);
		}
	}
}
