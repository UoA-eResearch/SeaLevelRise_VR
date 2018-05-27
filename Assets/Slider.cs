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
        if (currentLinearMapping != linearMapping.value) {
            currentLinearMapping = linearMapping.value;

            //Map the new slider value (value between 0 and 1) to a decade in the range 2000 to 2150
            var mappedToDecade = (currentLinearMapping - 0.0f) / (1.0f - 0.0f) * (2150.0f - 2000.0f) + 2000.0f;
            sliderValue = Mathf.RoundToInt(mappedToDecade / 10) * 10;

            dateText.GetComponent<Text>().text = "";
            dateText.GetComponent<Text>().text = "Year: " + sliderValue;

            GetComponentInParent<Rise>().SetSeaLevelAtDate(getDateString());
        }
    }

    private string getDateString() {

        var dateString = "1/01/" + sliderValue;
        return dateString;
    }
}
