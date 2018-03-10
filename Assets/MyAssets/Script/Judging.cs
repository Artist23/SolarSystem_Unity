using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class Judging : MonoBehaviour  {

    string rightAnswer;
    string myAns;
    GameObject scoreBoard;
    GameObject button1,button2,button3;
    Text score;
    float countDown=2.0f;
    public bool updateOn = true;
    float lastTime;


    void Start () {
        
        rightAnswer = ShowQuestion.GetRightAnswer();
        scoreBoard = GameObject.Find("ScoreBoard");
        score=scoreBoard.GetComponentInChildren<Text>();
        button1 = GameObject.Find("Button1");
        button2 = GameObject.Find("Button2");
        button3 = GameObject.Find("Button3");
        button1.GetComponent<Button>().onClick.AddListener(() => Judge(button1));
        button2.GetComponent<Button>().onClick.AddListener(() => Judge(button2));
        button3.GetComponent<Button>().onClick.AddListener(() => Judge(button3));
             
    }

    void Judge(GameObject button)
    {
        if (Time.time - lastTime < 5)
        {
            return;
        }
        if (rightAnswer == null)
        {
            rightAnswer = ShowQuestion.GetRightAnswer();
        }
        myAns = button.GetComponentInChildren<Text>().text;
        if(myAns==rightAnswer)
        {
            score.text = "That's right!";
            ShowQuestion.ReadTask();
            ShowQuestion.Show();
            rightAnswer = ShowQuestion.GetRightAnswer();
        }
        else
        {
            score.text = "Try Again";
        }
        lastTime = Time.time;
        updateOn = true;
    }

	void Update () {

        if (updateOn == true)
        {
            updateOn = false;
            
        }  
    }
    
}
