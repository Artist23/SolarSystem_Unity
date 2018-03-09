using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class res : MonoBehaviour {

	// Use this for initialization
    String ReadResFromXml(String target)
    {
        String text;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.dataPath + "\\MyAssets\\Resource\\Info.xml");
        XmlNode Child = xmlDoc.SelectSingleNode("Solar/" + target);
        text = Child.InnerText;     
        return text;
    }


    void Start () {
        //GameObject text = GameObject.Find("Text");
        Text t = gameObject.GetComponent<Text>();
        String name = gameObject.scene.name;
        t.text = ReadResFromXml(name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
