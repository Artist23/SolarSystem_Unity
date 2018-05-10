using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class Judging : MonoBehaviour  {

    string rightAnswer;    //the right answer
    string myAns;          //the answer that user chose
    GameObject scoreBoard; //the score board 
    GameObject button1,button2,button3;   //3 button for options
    Text score;                           //score
    float countDown=2.0f;                 //focus on a button for 2 seconds to select it
    public bool updateOn = true;          //update control
    float lastTime;


    void Start () {
        
        rightAnswer = ShowQuestion.GetRightAnswer();      //get the right answer
        scoreBoard = GameObject.Find("ScoreBoard");       //get scoreboard object
        score=scoreBoard.GetComponentInChildren<Text>();  //get text componnet of scoreboard
        button1 = GameObject.Find("Button1");             //get all the buttons with names
        button2 = GameObject.Find("Button2");
        button3 = GameObject.Find("Button3");
        button1.GetComponent<Button>().onClick.AddListener(() => Judge(button1));  //listen to onClick event, then call Judge()
        button2.GetComponent<Button>().onClick.AddListener(() => Judge(button2));
        button3.GetComponent<Button>().onClick.AddListener(() => Judge(button3));
             
    }

    void Judge(GameObject button)   //judge the button that user have just selected
    {
        if (Time.time - lastTime < 5)
        {
            return;
        }
        if (rightAnswer == null)
        {
            rightAnswer = ShowQuestion.GetRightAnswer();
        }

        myAns = button.GetComponentInChildren<Text>().text;  //get text on the selected button

        if(myAns==rightAnswer)  //if the answer is right
        {
            score.text = "That's right!";
            ShowQuestion.ReadTask();       //read the next question and options and right answer
            ShowQuestion.Show();           //show the next question and options
            rightAnswer = ShowQuestion.GetRightAnswer();  //update the right answer 
        }
        else
        {
            score.text = "Try Again";  //if not right then print try again
        }
        lastTime = Time.time;
        updateOn = true;
    }

	void Update () {

        if (updateOn == true)  
        {
            updateOn = false;  //update pause
            
        }  
    }
    
}
