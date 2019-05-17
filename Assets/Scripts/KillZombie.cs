using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour
{
	
	//public GameObject zombie;
	bool spawn = true;

    public AudioSource ballBounce;
	
	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision col){
        //play ball sound 
        if(!col.gameObject.name.Contains("Cylinder")){
            ballBounce.Play();
        }


		if(col.gameObject.tag == "Zombie"){

            // add to score
            Manager.Instance.zombieScore++;
            
			col.gameObject.GetComponent<Animation>().Play("fallingback 1");
			col.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			
			StartCoroutine(ZombieWait(col.gameObject));
			
			Manager.Instance.zombieSpawnRate -= 10;
			//Destroy(col.gameObject);//
		}
		
		if(col.gameObject.tag == "ZombieFloor" ){
            Debug.Log("BALL HIT ZOMBIEFLOOR");
            StartCoroutine(Wait(this.gameObject));
			
			if(spawn){
				if(this.gameObject.name.Contains("Ball1")){
						Instantiate(this.gameObject, new Vector3(.75f, 1, .75f), new Quaternion());
				}
				if(this.gameObject.name.Contains("Ball2")){
						Instantiate(this.gameObject, new Vector3(-.75f, 1f, .75f), new Quaternion());
				}
				if(this.gameObject.name.Contains("Ball3")){
						Instantiate(this.gameObject, new Vector3(-.75f, 1f, -.75f), new Quaternion());
				}
				if(this.gameObject.name.Contains("Ball4")){
						Instantiate(this.gameObject, new Vector3(.75f, 1f, -.75f), new Quaternion());
				}								
				spawn = false;
			}
        }
	}
	
	IEnumerator ZombieWait(GameObject zomb){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(1.0f);
        Destroy(zomb);
    }
	
    IEnumerator Wait(GameObject youDie){
        //Debug.Log("WAITING...");
        // process pre-yield
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fade(youDie));
    }

    IEnumerator Fade(GameObject killMe) {
        Renderer rend = killMe.GetComponent<Renderer>();
        Color start = rend.material.color;
        float duration = 1.0f;

        for (float t = 0f; t < duration; t += Time.deltaTime) {
            float normalizedTime = t/duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            rend.material.color = Color.Lerp(start, Color.clear, normalizedTime);
            yield return null;
        }
        rend.material.color = Color.clear; //without this, the value will end at something like 0.9992367
        Destroy(killMe);
    }
	
	
}
