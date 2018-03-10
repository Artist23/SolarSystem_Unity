using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour {

    static int nQuestionNumber=1;
    static string strQuestionPath;
    static Text questionSheet;
    static string strQuestion;
    static string strRightAnswer;
    static string a1, a2, a3;

    static string GetNextQuestionPath ()
    {
         strQuestionPath = string.Format("QA/Question{0}", nQuestionNumber);
         ++nQuestionNumber; 
         return strQuestionPath;
    }

    public static void ReadTask()
    {
        if (nQuestionNumber > ReadFromXml.NumberOfQuestions("\\MyAssets\\Resource\\QA.xml"))
        {
            return;
        }
        XmlNode node = ReadFromXml.Read("\\MyAssets\\Resource\\QA.xml", GetNextQuestionPath());
        strQuestion = node.SelectSingleNode("q").InnerText;
        a1 = node.SelectSingleNode("a1").InnerText;
        a2 = node.SelectSingleNode("a2").InnerText;
        a3 = node.SelectSingleNode("a3").InnerText;
        strRightAnswer = node.SelectSingleNode("rightAnswer").InnerText;
    }

    public static void Show()
    {
        questionSheet.text = strQuestion;
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        buttons[0].GetComponentInChildren<Text>().text = a1;
        buttons[1].GetComponentInChildren<Text>().text = a2;
        buttons[2].GetComponentInChildren<Text>().text = a3;
    }

    public static string GetRightAnswer()
    {
        return strRightAnswer;
    }

	void Start () {
        ReadTask();
        questionSheet = gameObject.GetComponent<Text>();

        if (nQuestionNumber <= ReadFromXml.NumberOfQuestions("\\MyAssets\\Resource\\QA.xml"))
        {
            Show();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
