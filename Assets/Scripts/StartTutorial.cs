using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{

    public AudioSource startVoice;
    // Start is called before the first frame update
    void Start()
    {
        startVoice.PlayDelayed(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
