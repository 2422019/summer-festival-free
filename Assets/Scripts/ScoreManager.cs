using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	private Text scoreText;
	private int score = 0;

	void Start()
	{
		scoreText = GetComponentInChildren<Text>();
		scoreText.text = "0";
	}

	void Update()
	{
		scoreText.text = score.ToString();
	}
}
