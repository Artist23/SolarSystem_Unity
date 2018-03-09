using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ReadFromXml  {

	public static string Read(string path, string target)
    {
        XmlDocument XmlDoc = new XmlDocument();
        XmlDoc.Load(Application.dataPath + path );
        XmlNode node = XmlDoc.SelectSingleNode(target);
        string text = node.InnerText;
        return text;
    }
    public static int NumberOfQuestions(string path)
    {
        XmlDocument XmlDoc = new XmlDocument();
        XmlDoc.Load(Application.dataPath + path);
        string questionNumber = XmlDoc.FirstChild.Attributes["number"].Value;
        return int.Parse(questionNumber);
    }

}
