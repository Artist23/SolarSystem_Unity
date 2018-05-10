using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour {

    static int nQuestionNumber=1;    //question index
    static string strQuestionPath;   //question‘s path
    static Text questionSheet;       //the text on UI which is called question sheet
    static string strQuestion;       //Question 
    static string strRightAnswer;    //the right answer
    static string a1, a2, a3;        //3 options

    static string GetNextQuestionPath ()  //get question path
    {
         strQuestionPath = string.Format("QA/Question{0}", nQuestionNumber);  //set question path with its number
         ++nQuestionNumber;          //ready to get next question
         return strQuestionPath;     //return the question path
    }

    public static void ReadTask()    //read the whole task(question + 3 options)
    {
        if (nQuestionNumber > ReadFromXml.NumberOfQuestions("\\MyAssets\\Resources\\QA.xml"))
        {
            return;    //to end the tasks
        }
        //get the target node with question path
        XmlNode node = ReadFromXml.Read("\\MyAssets\\Resources\\QA.xml", GetNextQuestionPath()); 
        strQuestion = node.SelectSingleNode("q").InnerText;   //get question string
        a1 = node.SelectSingleNode("a1").InnerText;           //get all 3 options
        a2 = node.SelectSingleNode("a2").InnerText;
        a3 = node.SelectSingleNode("a3").InnerText;
        strRightAnswer = node.SelectSingleNode("rightAnswer").InnerText;  //get the right answer
    }

    public static void Show()     //add to UI
    {
        questionSheet.text = strQuestion;     //show question
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button"); //get all the 3 button
        buttons[0].GetComponentInChildren<Text>().text = a1;  //change the button text to options
        buttons[1].GetComponentInChildren<Text>().text = a2;
        buttons[2].GetComponentInChildren<Text>().text = a3;
    }

    public static string GetRightAnswer()  //get the right answer
    {
        return strRightAnswer;
    }

	void Start () {
       
        TextAsset myText = Resources.Load("QA") as TextAsset;  //load Xml file from resources
        ReadTask();                                            //read the whole task
        questionSheet = gameObject.GetComponent<Text>();       //get the text component of UI

        if (nQuestionNumber <= ReadFromXml.NumberOfQuestions("\\MyAssets\\Resources\\QA.xml"))
        {
            Show();   
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
