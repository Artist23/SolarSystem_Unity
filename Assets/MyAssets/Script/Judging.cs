using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class Judging : MonoBehaviour  {

    List<string> rightAnswers;    //the right answer
    List<string> myAnswers;          //the answer that user chose
    GameObject scoreBoard; //the score board 
    GameObject[] buttons;   //3 button for options
    GameObject[] toggles;
    Button confirmButton;
    Text score;                           //score
    float countDown=2.0f;                 //focus on a button for 2 seconds to select it
    public bool updateOn = true;          //update control
    float lastTime;
    int id = 1;


    void Start () {

        rightAnswers = ReadFromXml.ReadRightAnswers(id);
        scoreBoard = GameObject.Find("ScoreBoard");       //get scoreboard object
        score=scoreBoard.GetComponentInChildren<Text>();  //get text componnet of scoreboard
        if (rightAnswers == null)
        {
            return;
        }
        
        confirmButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
        toggles = GameObject.FindGameObjectsWithTag("Toggle");
        confirmButton.onClick.AddListener(() => Judge(toggles));

        
        buttons = GameObject.FindGameObjectsWithTag("Button");
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().onClick.AddListener(() => Judge(buttons[i]));
        }
        
    }
    
    void Judge(GameObject button)   //judge the button that user have just selected
    {

        if (Time.time - lastTime < 5)
        {
            return;
        }
        rightAnswers = ReadFromXml.ReadRightAnswers(id);
        if (rightAnswers.Count == 1)
        {
            string myAns = button.GetComponentInChildren<Text>().text;
            if (myAns == rightAnswers[0])  //if the answer is right
            {
                score.text = "That's right!";
                id++;
                ShowQuestion.Show();           //show the next question and options
                rightAnswers = ReadFromXml.ReadRightAnswers(id);  //update the right answer 
            }
            else
            {
                score.text = "Try Again";  //if not right then print try again
            }
            lastTime = Time.time;
            updateOn = true;
        }
    }

    void Judge (GameObject[] toggles)
    {
        
        rightAnswers = ReadFromXml.ReadRightAnswers(id);
        if(toggles.Length == rightAnswers.Count )
        {
            foreach(GameObject toggle in toggles)
            {
                if(!rightAnswers.Contains(toggle.GetComponent<Text>().text))
                {
                    score.text = "Try again";
                    return;
                }
            }
            score.text = "That's right!";
            return;
        }
        score.text = "Try again";
    }

	void Update () {

        if (updateOn == true)  
        {
            updateOn = false;  //update pause
            
        }  
    }
    
}
