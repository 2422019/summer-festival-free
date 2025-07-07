using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCounter : MonoBehaviour
{

	private int countdownMinutes = 1;
	private float countdownSeconds;
	private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
		timeText = GetComponent<Text>();
		countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
		countdownSeconds -= Time.deltaTime;
		var span = new TimeSpan(0, 0, (int)countdownSeconds);
		timeText.text = span.ToString(@"mm\:ss"); 

		if(countdownSeconds <= 0 )
		{
			Debug.Log("60•bŒo‰ß‚µ‚Ü‚µ‚½B");
		}
    }
}
