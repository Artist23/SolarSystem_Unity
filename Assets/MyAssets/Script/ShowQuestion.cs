using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour {

    private static Text questionText;
    private static int id = 1;
    public static GameObject oriButton;
    public static GameObject oriToggle;
    public static Transform answerSheet;
    public static GameObject[] buttons;
    public static GameObject[] toggles;
    public static bool isMultiType;

    void Start()
    {
        oriButton = GameObject.Find("Button1");  //get original button
        oriToggle = GameObject.Find("Toggle");   //get original toggle
        answerSheet = GameObject.Find("Answers").transform;   //get transform of answersheet 
        TextAsset myText = Resources.Load("QAtest") as TextAsset;  //load Xml file from resources
        questionText = GameObject.Find("Question").GetComponentInChildren<Text>(); //find question text component

        Show();
    }

    public static void Show()
    {

        questionText.text = ReadFromXml.ReadQuestion(id);  //show question
        
        isMultiType = ReadFromXml.IsMulti(id);   //get question type
        List<string> optionList = ReadFromXml.ReadAnswers(id);  //read options
        int optionNum = optionList.Count;

        if (isMultiType)  //if type_multiple
        {
            Vector3 originalTogglePosition = oriToggle.transform.position;
            toggles = new GameObject[optionNum];
            for(int i=0; i < optionNum; i++)
            {
                toggles[i] = GameObject.Instantiate(oriToggle, answerSheet);
                Text optionText = toggles[i].GetComponentInChildren<Text>();
                optionText.text = optionList[i];
                toggles[i].tag = "Toggle";
                toggles[i].transform.position = originalTogglePosition;
                originalTogglePosition += Vector3.down * 0.12f;
            }
            return;
        }

        Vector3 originalPosition = oriButton.transform.position; 
        buttons = new GameObject[optionNum];
        for(int i =0; i < optionNum; i++)
        {

            buttons[i] = GameObject.Instantiate(oriButton,answerSheet);
            Text optionText = buttons[i].GetComponentInChildren<Text>();
            optionText.text = optionList[i];
            buttons[i].tag = "Button";
            buttons[i].transform.position = originalPosition;
            originalPosition += Vector3.down * 0.2f;
        }
        id++;
    }
	
}
