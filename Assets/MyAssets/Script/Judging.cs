using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class Judging : MonoBehaviour  {

    string rightAnswer;
    string myAns;
    GameObject scoreBoard;
    Text score;
    float countDown=2.0f;
    public bool updateOn = true;

    void Start () {

        rightAnswer = ReadFromXml.Read("\\MyAssets\\Resource\\QA.xml","QA/Question1/rightAnswer");
        scoreBoard = GameObject.Find("ScoreBoard");
        score=scoreBoard.GetComponentInChildren<Text>();

    }
	
	void Judge()
    { 
        if(myAns==rightAnswer)
        {
            score.text = "That's right!";
            updateOn = false;
            countDown -= Time.deltaTime;
            if(countDown <= 0.0f)
            {
                ShowQuestion.Show();
                
            }
        }
        else
        {
            score.text = "Try Again";
        }   
    }

	void Update () {

        if (updateOn == true)
        {
            myAns = gameObject.GetComponentInChildren<Text>().text;
            gameObject.GetComponent<Button>().onClick.AddListener(Judge);
        }  
    }
    
}
