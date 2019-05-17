using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

	public GameObject zombie;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// pick random point on circle circumfrence
		Vector2 randomUnitCircle = Random.insideUnitCircle.normalized * 40;
		
		Vector3 point = new Vector3(randomUnitCircle.x, 0, randomUnitCircle.y);
		//randomUnitCircle.Scale(new Vector3(50f,50f,50f)); //50,50,50 is the radius of the circle


		//if current frame number is divisible by zombieSawnRate (default), spawn a zombie
		if(Time.frameCount % Manager.Instance.zombieSpawnRate == 0){
			// could pick random number to spawn different zombie types
			GameObject z = Instantiate(zombie, point, new Quaternion());
			z.SetActive(true);
		}
	}
}
