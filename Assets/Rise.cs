using System;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class Rise : MonoBehaviour
{

    private string[,] dataArray;
    private string[] dateArray;
    private GameObject ocean;
    private string date;
    private GameObject seaLevelText;
    private int pos = 0;
    public bool pauseAnimation;
    public Button toggleButton;
    public LinearMapping linearMapping;


    void Start()
    {
        ocean = GameObject.Find("Ocean");
        seaLevelText = GameObject.Find("SeaLevelDyn");
        pauseAnimation = false;

        //Load sea level data and dates from file and store in data array
        var dataFile = Resources.Load<TextAsset>("Data");

        string[] fileContent = dataFile.text.Split('\n');
        dataArray = new string[fileContent.Length, 2];
        dateArray = new string[fileContent.Length];

        for (var pos = 0; pos < fileContent.Length; pos++)
        {
            var content = fileContent[pos].Split(' ');
            dataArray[pos, 0] = content[0];
            dataArray[pos, 1] = content[1];

            dateArray[pos] = content[0];
        }

        InvokeRepeating("Animate", 2.0f, 1);
    }

    /*
    Animate the sea level rise automatically
    */
    void Animate()
    {

        if (!pauseAnimation)
        {
            if (pos >= dataArray.GetLength(0))
            {
                pos = 0;
            }

            var date = dataArray[pos, 0];
            //var seaLevel = dataArray[pos, 1];

            float mappedToRange0_1 = (float.Parse(date.Split('/')[2]) - 2000.0f) / (2150.0f - 2000.0f) * (1.0f - 0.0f) + 0.0f;

            linearMapping.value = mappedToRange0_1;

            pos++;
        }
    }

    /*
    Pause and Resume automatic animation of sea level rise
    */
    public void ToggleBut()
    {
        if (pauseAnimation)
        {
            pauseAnimation = false;
            toggleButton.GetComponentInChildren<Text>().text = "";
            toggleButton.GetComponentInChildren<Text>().text = "Pause Animation";
        }
        else
        {
            pauseAnimation = true;
            toggleButton.GetComponentInChildren<Text>().text = "";
            toggleButton.GetComponentInChildren<Text>().text = "Resume Animation";
        }
    }

    /*
    Animate the sea level rise automatically
    */
    public void SetSeaLevelAtDate(string timeString)
    {
        float seaLevel = 0.0F;
        for (var position = 0; position < dataArray.GetLength(0); position++)
        {

            var strVal1 = dataArray[position, 0].ToString().Split('/');

            if (position == (dataArray.GetLength(0) - 1) && Int32.Parse(timeString.Split('/')[2]) >= Int32.Parse(strVal1[2]))
            {
                seaLevel = float.Parse(dataArray[position, 1]);
                ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);

                seaLevelText.GetComponent<Text>().text = "";
                seaLevelText.GetComponent<Text>().text = seaLevel.ToString();
            }
            else
            {
                var strVal2 = dataArray[position + 1, 0].Split('/');
                var splitTime = timeString.Split('/');
                if (Int32.Parse(strVal1[2]) <= Int32.Parse(splitTime[2]) && Int32.Parse(strVal2[2]) > Int32.Parse(splitTime[2]))
                {
                    seaLevel = float.Parse(dataArray[position, 1]);
                    ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);

                    seaLevelText.GetComponent<Text>().text = "";
                    seaLevelText.GetComponent<Text>().text = seaLevel.ToString();

                    break;
                }
            }

        }
    }


    /*
    Keep track of which position/index in the data array is currently shown as sea level and date
    */
    public void SetCurrentPosition(string dateString)
    {
        pos = Array.IndexOf(dateArray, dateString);
    }

}