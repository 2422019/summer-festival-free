using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	// ドーナツ
	[SerializeField]
	GameObject donutObj;

	private const int arrayWidth = 10;
	private const int arrayHeight = 10;

	// 二次元配列
	private int[,] squares = new int[arrayWidth, arrayHeight];

	private const int ENPTY = 0;

	// カメラ情報
	private Camera camera_object;
	private RaycastHit hit;

	//　回転角速度
	[SerializeField] private Vector3 angleVelocity;

	// 成功フラグ
	//bool success = false;

	void Start()
	{
		// カメラ情報を取得
		camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();

		// 配列を初期化
		InitializeArray();

		// デバッグ用
		//DebugArray();
	}

	void Update()
	{
		// マウスがクリックされた時
		if(Input.GetMouseButtonDown(0))
		{
			// マウスのポジションを取得してRayに代入
			Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

			// マウスのポジションからRayを飛ばして何かに当たったらhitに入れる
			if (Physics.Raycast(ray, out hit))
			{
				int x = (int)hit.collider.gameObject.transform.position.x;
				int z = (int)hit.collider.gameObject.transform.position.z;

				if (squares[z,x] == ENPTY)
				{
					// Squaresの値を更新
					squares[z, x] = ENPTY;

					// ドーナツを出力
					//success = true;
					GameObject donut = Instantiate(donutObj);
					donut.transform.position = hit.collider.gameObject.transform.position;
					Debug.Log("ドーナツ生成");
				}

				if(hit.collider.gameObject.CompareTag("Donut"))
				{
					transform.localEulerAngles += angleVelocity * Time.deltaTime;
					Debug.Log("回転");
				}

				else if(donutObj.activeSelf == true)
				{
					Debug.Log("既に存在します");
					return;
				}

				/*
				if (hit.collider.gameObject.CompareTag("Donut"))
				{
					hit.transform.Rotate(0, 0, 180);
					Debug.Log("ドーナツあり");
					//hit.collider.gameObject.SetActive(false);
				}
				*/
			}
		}
	}

	private void InitializeArray()
	{
		// 配列にアクセス
		for(int i = 0; i < arrayWidth; i++)
		{
			for(int j = 0; j < arrayHeight; j++)
			{
				// 配列を空にする
				squares[i, j] = ENPTY;
			}
		}
	}

	// デバッグ用
	/*
	private void DebugArray()
	{
		for (int i = 0; i < arrayWidth; i++)
		{
			for (int j = 0; j < arrayHeight; j++)
			{
				Debug.Log("(i,j) = (" + i + "," + j + ") = " + squares[i, j]);
			}
		}
	}
	*/
}
