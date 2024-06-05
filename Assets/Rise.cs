using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rise : MonoBehaviour
{

	private float[,] dataArray;
	private string[] dateArray;
	private GameObject ocean;
	private int pos = 0;
	public bool pauseAnimation = false;
	public bool addTide = true;
	public bool addStorm = true;
	public Button toggleButton;
	public Button tideButton;
	public Button stormButton;
	public Slider slider;
	public Transform startPosition;
	public Transform endPosition;
	public TextMeshProUGUI seaLevelText;


	void Start()
	{
		ocean = GameObject.Find("Ocean");
		pauseAnimation = false;

		//Load sea level data and dates from file and store in data array
		var dataFile = Resources.Load<TextAsset>("Data");

		string[] fileContent = dataFile.text.Split('\n');
		dataArray = new float[fileContent.Length, 2];
		dateArray = new string[fileContent.Length];

		for (var pos = 0; pos < fileContent.Length; pos++)
		{
			var content = fileContent[pos].Split(' ');
			dataArray[pos, 0] = int.Parse(content[0]);
			dataArray[pos, 1] = float.Parse(content[1]);

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

			var year = dataArray[pos, 0];
			SetSeaLevelAtDate((int)year);

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
			toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
		}
		else
		{
			pauseAnimation = true;
			toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play";
		}
	}


	/*
	Add and Remove Tide
	*/
	public void ToggleTide()
	{
		if (addTide)
		{
			addTide = false;
			tideButton.GetComponentInChildren<TextMeshProUGUI>().text = "Add Tide";
		}
		else
		{
			addTide = true;
			tideButton.GetComponentInChildren<TextMeshProUGUI>().text = "Remove Tide";
		}
		SetSeaLevelAtDate((int)slider.value);
	}


	/*
	Add and Remove Storm Surge
	*/
	public void ToggleStorm()
	{
		if (addStorm)
		{
			addStorm = false;
			stormButton.GetComponentInChildren<TextMeshProUGUI>().text = "Add Storm";
		}
		else
		{
			addStorm = true;
			stormButton.GetComponentInChildren<TextMeshProUGUI>().text = "Remove Storm";
		}
		SetSeaLevelAtDate((int)slider.value);
	}

	public void SetSeaLevelAtDate(int year)
	{
		float seaLevel = 0.0F;
		for (int i = 0; i < dataArray.GetLength(0) - 1; i++) {
			if (dataArray[i, 0] <= year && dataArray[i + 1, 0] >= year) {
				var lowerSlr = dataArray[i, 1];
				var upperSlr = dataArray[i + 1, 1];
				var lowerYear = dataArray[i, 0];
				var upperYear = dataArray[i + 1, 0];
				seaLevel = lowerSlr + ((year - lowerYear) / (upperYear - lowerYear)) * (upperSlr - lowerSlr);
				Debug.Log(seaLevel);
				if (addTide) {
					seaLevel += 1.949f;
				}
				if (addStorm) {
					seaLevel += 0.45f;
				}
				Debug.Log(seaLevel);
				ocean.transform.position = new Vector3(0, seaLevel * 0.01F, 0);
				slider.value = year;
				seaLevelText.text = year.ToString() + ": " + seaLevel.ToString() + "m";
			}
		}
	}
}