using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class ReadFromXml  {

    private static XmlDocument XmlDoc;
    private static TextAsset myText;

    //read multiple strings
	public static XmlNode ReadTask(string target, int id)
    {
        //load Xml doc
        XmlDoc = new XmlDocument();
        myText = Resources.Load("QAtest") as TextAsset;
        XmlDoc.LoadXml(myText.text);
        if (XmlDoc == null)
        {
            return null;
        }
        //lode text

        XmlNodeList nodes = XmlDoc.SelectNodes(target);
        int i = nodes.Count;
        foreach(XmlNode task in nodes)
        {
            if(int.Parse(task.Attributes["id"].Value) == id)
            {
                return task;
            }
        }
        return null;
    }


    public static List<string> Read(string name, int id)
    {
        //read task
        XmlNode task = ReadTask("//Question", id);
        XmlNodeList children = task.ChildNodes;
        List<string> list = new List<string>();
        //get string list
        foreach (XmlNode child in children)
        {
            if (child.Name == name)
            {
                list.Add(child.InnerText);
            }
        }
        return list;
    }


    public static string ReadQuestion(int id)
    {

        List<string> questions = Read("q", id);
        if (questions != null)
        {
            return questions[0];
        }
        return "";
    }

    public static List<string> ReadAnswers(int id)
    {
        List<string> ansList = Read("a", id);
        return ansList;
    }
   
    public static List<string> ReadRightAnswers(int id)
    {
        List<string> rightAnswers = Read("rightAnswer", id);
        return rightAnswers;
    }
    public static bool IsMulti(int id)
    {
        XmlNode task = ReadTask("//Question", id);
        string typeValue = task.Attributes["type"].Value;
        if (typeValue == "multi")
        {
            return true;
        }
        return false;
    }

    public static int CountTasks()
    {
        //load Xml doc
        XmlDoc = new XmlDocument();
        myText = Resources.Load("QAtest") as TextAsset;
        XmlDoc.LoadXml(myText.text);
        //return int.Parse(questionNumber);
        return XmlDoc.ChildNodes.Count;
    }

    
}
