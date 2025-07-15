using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScene : MonoBehaviour
{
	[SerializeField] private string loadScene;
	[SerializeField] private Color fadeColor = Color.black;
	[SerializeField] private float fadeSpeedMultiplier = 1.0f;

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			{
				Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
			}
		}
	}
}
