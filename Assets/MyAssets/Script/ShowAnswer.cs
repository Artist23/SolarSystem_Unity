using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowAnswer : MonoBehaviour {

    static int nQuestionNumber = 1;
    static string strQuestionPath;
    static GameObject[] buttons;
    
    static string GetNextQuestionPath()
    {
        strQuestionPath = string.Format("QA/Question{0}/a", nQuestionNumber);
        ++nQuestionNumber;
        return strQuestionPath;
    }
    public static void Show()
    {
        var num = 1;
        buttons = GameObject.FindGameObjectsWithTag("Button");
        string questionPath = GetNextQuestionPath();
        foreach (GameObject button in buttons)
        {
            string answer = ReadFromXml.Read("\\MyAssets\\Resource\\QA.xml",questionPath + num);
            button.GetComponentInChildren<Text>().text = answer;
            num++;
        }
    }
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
