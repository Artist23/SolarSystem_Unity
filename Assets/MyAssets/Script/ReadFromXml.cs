using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class ReadFromXml  {

	public static XmlNode Read(string path, string target)
    {
        XmlDocument XmlDoc = new XmlDocument();
        TextAsset myText = Resources.Load("QA") as TextAsset;
        //XmlDoc.Load(Application.dataPath + path );
        XmlDoc.LoadXml(myText.text);
        XmlNode node = XmlDoc.SelectSingleNode(target);
        return node;
    }
    public static int NumberOfQuestions(string path)
    {
        XmlDocument XmlDoc = new XmlDocument();
        XmlDoc.Load(Application.dataPath + path);
        string questionNumber = XmlDoc.FirstChild.Attributes["number"].Value;
        return int.Parse(questionNumber);
    }

}
