using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackBoardCollision : MonoBehaviour
{

    public AudioClip bbsound;
    AudioSource bbSource;
    // Start is called before the first frame update
    void Start()
    {
        bbSource = this.gameObject.GetComponent<AudioSource>();
        bbSource.clip = bbsound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        bbSource.Play();
    }
}
