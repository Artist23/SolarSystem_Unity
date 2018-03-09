using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour {

    static int nQuestionNumber;
    static string strQuestionPath;
    static Text questionSheet; 

    static string GetNextQuestionPath ()
    {
        
         strQuestionPath = string.Format("QA/Question{0}/q{1}", nQuestionNumber, nQuestionNumber);
         ++nQuestionNumber; 
         return strQuestionPath;
            
        
    }

    public static void Show()
    {
        questionSheet.text = ReadFromXml.Read("\\MyAssets\\Resource\\QA.xml", GetNextQuestionPath());
        ShowAnswer.Show();
    }

	void Start () {
        nQuestionNumber = 1;
        questionSheet  = gameObject.GetComponent<Text>();
        
        if(nQuestionNumber<=ReadFromXml.NumberOfQuestions("\\MyAssets\\Resource\\QA.xml"))
        {
            Show();      
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
