using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDistTele : MonoBehaviour
{
	public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
		
		//Debug.Log(Vector3.Distance(player.transform.position, this.gameObject.transform.position));
		
        if(Vector3.Distance(player.transform.position, this.gameObject.transform.position) <= 2){
			Destroy(GameObject.Find("Player"));
			SceneManager.LoadScene(1);
		}
    }
}
