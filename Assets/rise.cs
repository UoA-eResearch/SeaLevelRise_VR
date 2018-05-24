using System;
using UnityEngine;
using UnityEngine.UI;

public class Rise : MonoBehaviour {

    private string[,] dataArray;
    private GameObject ocean;
    private string date;
    private GameObject dateText;
    private GameObject seaLevelText;
    private int pos = 0;
    public bool pauseAnimation = false;

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
        dateText = GameObject.Find("DateDyn");
        seaLevelText = GameObject.Find("SeaLevelDyn");

        InvokeRepeating("animate", 2.0f, 1);
    }


    void animate() {
        
        if (!pauseAnimation) {

            if (pos >= dataArray.GetLength(0))
            {
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
    }

    
    public void setSeaLevelAtDate(string timeString)
    {
        float seaLevel = 0.0F;
        for (var pos = 0; pos < dataArray.GetLength(0); pos++)
        {
            Debug.Log(pos + " and " + timeString);
            var strVal1 = dataArray[pos, 0].ToString().Split('/');

            if (pos == (dataArray.GetLength(0)-1) && Int32.Parse(timeString.Split('/')[2]) >= Int32.Parse(strVal1[2])) {

                seaLevel = float.Parse(dataArray[pos, 1]);
                ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);

                seaLevelText.GetComponent<Text>().text = "";
                seaLevelText.GetComponent<Text>().text = seaLevel.ToString();
                Debug.Log(seaLevel.ToString() + " here " + timeString);
                break;
            }
            
            var strVal2 = dataArray[pos + 1, 0].Split('/');
            var splitTime = timeString.Split('/');
            if (Int32.Parse(strVal1[2]) <= Int32.Parse(splitTime[2]) && Int32.Parse(strVal2[2]) > Int32.Parse(splitTime[2]))
            {
                seaLevel = float.Parse(dataArray[pos, 1]);
                ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);

                seaLevelText.GetComponent<Text>().text = "";
                seaLevelText.GetComponent<Text>().text = seaLevel.ToString();
            }
            
        }
    }


    // Update is called once per frame
    void Update () {
	}
}
