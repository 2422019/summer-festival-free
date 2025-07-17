using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDisPlay : MonoBehaviour
{
		/*
	// ‰æ‘œ
	[SerializeField]
	GameObject image;

	Quaternion defaultRotation;
	Vector3 defaultPos;

	void Start()
	{
		defaultPos		= image.transform.localPosition;
		defaultRotation = image.transform.localRotation;
	}

	void Update()
	{

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{
			image.transform.rotation = Quaternion.LookRotation(hit.normal);
			image.transform.position = hit.point + (hit.normal);
			Debug.Log("hello word");
		}

		else
		{
			image.transform.localPosition = new Vector3(0, 0, defaultPos.z);
			image.transform.localRotation = defaultRotation;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.CompareTag("TemporaryGrid"))
			{
				image.SetActive(true);

				//Debug.Log(hit.point);
				Debug.Log("‰æ‘œ‚Ì•\Ž¦");
			}
		}
	}
		*/
}
