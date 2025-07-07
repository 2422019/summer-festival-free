using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDisPlay : MonoBehaviour
{
	// �摜
	[SerializeField]
	GameObject image;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.CompareTag("TemporaryGrid"))
			{
				image.SetActive(true);
				Debug.Log(hit.point);
				Debug.Log("�摜�̕\��");
			}
		}
	}
}
