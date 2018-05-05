using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour {

    String ReadResFromXml(String target)         //read from XML
    {
        String text;
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset myText = Resources.Load("Info") as TextAsset;
        xmlDoc.LoadXml(myText.text);
        XmlNode Child = xmlDoc.SelectSingleNode("Solar/" + target);
        text = Child.InnerText;     
        return text;
    }

    void Start () {
        //GameObject text = GameObject.Find("Text");
        Text t = gameObject.GetComponent<Text>();
        String name = gameObject.scene.name;          //get scene name
        t.text = ReadResFromXml(name);                //show the target infomation
    }

    void Update () {
		
	}
}
