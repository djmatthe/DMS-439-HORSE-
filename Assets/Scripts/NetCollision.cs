using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCollision : MonoBehaviour
{

    public AudioClip netSound;
    public AudioSource netSource;
    // Start is called before the first frame update
    void Start()
    {
        //netSource = this.gameObject.GetComponent<AudioSource>();
        netSource.clip = netSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        netSource.Play();
    }
}