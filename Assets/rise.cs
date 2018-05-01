using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rise : MonoBehaviour {

    string[,] dataArray;
    GameObject ocean;
    public string date;
    private GameObject dateText;
    private GameObject seaLevelText;
    private int pos = 0;

    // Use this for initialization
    void Start() {
        var dataFile = Resources.Load<TextAsset>("Data");

        string[] fileContent = dataFile.text.Split('\n');
        dataArray = new string[fileContent.Length, 2];

        for (var pos = 0; pos < fileContent.Length; pos++)
        {
            var content = fileContent[pos].Split(' ');
            dataArray[pos, 0] = content[0];
            dataArray[pos, 1] = content[1];
        }

        ocean = GameObject.Find("Ocean");
        dateText = GameObject.Find("Date");
        seaLevelText = GameObject.Find("SeaLevel");

        InvokeRepeating("animate", 2.0f, 1f);
    }


    void animate() {

        if (pos >= dataArray.GetLength(0)) {
            pos = 0;
        }
        
        var date = dataArray[pos, 0];
        var seaLevel = dataArray[pos, 1];

        ocean.transform.position = new Vector3(0, float.Parse(seaLevel) * 0.01F, 0);

        dateText.GetComponent<Text>().text = "";
        dateText.GetComponent<Text>().text = date;
        seaLevelText.GetComponent<Text>().text = "";
        seaLevelText.GetComponent<Text>().text = seaLevel;

        pos++;
    }



    // Update is called once per frame
    void Update () {
        
	}
}
