using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToLeaveTutorial : MonoBehaviour
{
    bool played = false;

    public AudioSource howToLeave;

    public GameObject startVoice;

    public GameObject teleLeave;

    public GameObject lightIndicator;

    AudioSource start; 
    // Start is called before the first frame update
    void Start()
    {
        start = startVoice.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Made First Shot: " + Manager.Instance.madeFirstTutorialShot);
        //Debug.Log("Already Played Sound: " + played);
        //Debug.Log("First Dialouge Playing: " + start.isPlaying);
        
        if(Manager.Instance.madeFirstTutorialShot && !played && !start.isPlaying){

            howToLeave.PlayDelayed(2);
            // unlock teleport point
            teleLeave.GetComponent<Valve.VR.InteractionSystem.TeleportPoint>().locked = false;
            lightIndicator.SetActive(true);
            played = true;
        }
    }

    // IEnumerator PlayAfterWait(){
    //     yield return new WaitForSeconds(2.0f);
    //     howToLeave.Play();
    // }
}
