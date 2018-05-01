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
    private GameObject sliderCanvas;
    private Text sliderText;

    //-------------------------------------------------
    void Awake()
    {
        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }

        sliderCanvas = GameObject.Find("pHCanvas");
        sliderText = sliderCanvas.GetComponentInChildren<Text>();
    }


    //-------------------------------------------------
    void Update()
    {
        if (currentLinearMapping != linearMapping.value)
        {
            currentLinearMapping = linearMapping.value;

            var mappedToPH = (currentLinearMapping - 0.0f) / (1.0f - 0.0f) * (9.0f - 3.0f) + 3.0f;
            sliderValue = Mathf.RoundToInt(mappedToPH);
            switch (sliderValue)
            {

                case 9:
                    sliderText.text = "pH value: high";
                    break;

                case 8:
                case 7:
                case 6:
                case 5:
                case 4:
                    sliderText.text = "pH value: " + sliderValue;
                    break;

                case 3:
                    sliderText.text = "pH value: low";
                    break;

            }
        }
    }

    public int GetPhValue()
    {
        return sliderValue;
    }
    public string GetPhValueStr()
    {
        return sliderText.text;
    }
}
