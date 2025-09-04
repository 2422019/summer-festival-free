using System.Collections;
using UnityEngine;

public class TurnOver : MonoBehaviour
{
	private bool rotateFlag = false; // 回転中フラグ
	private GameObject targetDonut;  // 回転させる対象

	[Header("色設定")]
	[SerializeField] private Color startColor = Color.yellow;					// 初期色
	[SerializeField] private Color cookColor = new Color(0.6f, 0.3f, 0.1f);		// 焼き色
	[SerializeField] private float cookTime = 2f;								// 色が変わるまでの時間

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("Donut"))
				{
					if (!rotateFlag)
					{
						targetDonut = hit.collider.gameObject;
						StartCoroutine(RotateMove(targetDonut));
						Debug.Log("回転開始");
					}
				}
			}
		}
	}

	IEnumerator RotateMove(GameObject donut)
	{
		rotateFlag = true;

		// Renderer取得
		Renderer rend = donut.GetComponent<Renderer>();
		if(rend == null) yield break;

		// 180°回転
		for (int i = 0; i < 360; i++)
		{
			donut.transform.Rotate(0, 0, 1);
			yield return new WaitForSeconds(0.01f);
		}

		// 色を時間経過で変える
		float timer = 0f;
		Color initialColor = rend.material.color; // 今の色を取得

		while (timer < cookTime)
		{
			timer += Time.deltaTime;
			float t = timer / cookTime;

			rend.material.color = Color.Lerp(initialColor, cookColor, t);

			//yield return null; // 1フレーム待つ

		}

		// 色を変える
		rend.material.color = cookColor;

		rotateFlag = false;
		Debug.Log("回転終了");
	}

}