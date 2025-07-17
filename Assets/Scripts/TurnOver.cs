using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOver : MonoBehaviour
{
	// ��]�����Ă��邩�̃t���O
	bool rotateFlag = false;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.CompareTag("Donut"))
				{
					if (!rotateFlag)
					{
						rotateFlag = true;
						StartCoroutine("RotateMove");
						Debug.Log("��]�J�n");
					}
				}
			}
		}
	}

	IEnumerator RotateMove()
	{
		for (int i = 0; i < 180; ++i)
		{
			transform.Rotate(0, 0, 1);
			yield return new WaitForSeconds(0.01f);
		}
		rotateFlag = false;
		Debug.Log("��]�I��");
	}
}
