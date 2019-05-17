using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    TextMesh board;
    string currentText;

    public AudioSource gotLetter;
    // Start is called before the first frame update
    void Start()
    {
        board = this.gameObject.GetComponent<TextMesh>();
        currentText = board.text = Manager.Instance.getHorseLetters();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(currentText != Manager.Instance.getHorseLetters()){
            currentText = board.text = Manager.Instance.getHorseLetters();
            if(this.gameObject.name == "ScoreBoard"){
                gotLetter.Play();
            }
        }  
    }
}
