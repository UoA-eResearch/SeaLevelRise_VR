using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;


public class Slider : MonoBehaviour
{

    public LinearMapping linearMapping;
    private float currentLinearMapping = float.NaN;
    private int sliderValue;
    private GameObject dateText;

    //-------------------------------------------------
    void Awake()
    {
        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }
        
        dateText = GameObject.Find("DateDyn");

    }


    //-------------------------------------------------
    void Update()
    {
        if (currentLinearMapping != linearMapping.value)
        {
            GetComponentInParent<Rise>().pauseAnimation = true;

            currentLinearMapping = linearMapping.value;

            var mappedToDecade = (currentLinearMapping - 0.0f) / (1.0f - 0.0f) * (2150.0f - 2000.0f) + 2000.0f;
            sliderValue = Mathf.RoundToInt(mappedToDecade);
            //sliderValue = Mathf.RoundToInt(mappedToDecade / 10) * 10;

            dateText.GetComponent<Text>().text = "";
            dateText.GetComponent<Text>().text = "Year: " + sliderValue;

            GetComponentInParent<Rise>().setSeaLevelAtDate(getDateString());
        }
    }

    private string getDateString() {

        var dateString = "1/01/" + sliderValue;

        return dateString;
    }

    public int GetPhValue()
    {
        return sliderValue;
    }
    public string GetPhValueStr()
    {
        return dateText.GetComponent<Text>().text;
    }
}
