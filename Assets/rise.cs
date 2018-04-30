using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rise : MonoBehaviour {

    string[,] dataArray;
    GameObject ocean;
    public string date;

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

        StartCoroutine(animate());
        //setSeaLevelAtDate("1/01/2100");
    }

    /*
    void setSeaLevelAtDate(string timeString)
    {
        float seaLevel;
        for (var pos = 0; pos < dataArray.GetLength(0)-1; pos++)
        {
            Debug.Log(pos);
            var strVal1 = dataArray[pos, 0].ToString().Split('/');
            var strVal2 = dataArray[pos + 1, 0].Split('/');
            var splitTime = timeString.Split('/');

            Debug.Log(strVal1[2]);
            Debug.Log(Int32.Parse(splitTime[2]));
            Debug.Log(strVal2[2]);
            Debug.Log(Int32.Parse(splitTime[2]));

            if (Int32.Parse(strVal1[2]) <= Int32.Parse(splitTime[2]) && Int32.Parse(strVal2[2]) > Int32.Parse(splitTime[2]))
            {

                seaLevel = float.Parse(dataArray[pos, 1]);
                ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);
            }
        }
    }
    */


    IEnumerator animate() {
        for (var pos = 0; pos < dataArray.GetLength(0) - 1; pos++) {
            yield return new WaitForSeconds(2.0F);
            var seaLevel = float.Parse(dataArray[pos, 1]);
            ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);
        }
    }



    // Update is called once per frame
    void Update () {
        
	}
}
