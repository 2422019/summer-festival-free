using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	// ドーナツ
	[SerializeField]
	GameObject donutObj;

	// パーティクル
	[SerializeField]
	private ParticleSystem particle;

	// 置く場所
    [SerializeField] private GameObject gridCellPrefab;

    private const int arrayWidth = 6;
	private const int arrayHeight = 4;

	// 二次元配列
	private int[,] squares = new int[arrayHeight, arrayWidth];

	private const int ENPTY = 0;
	private const int PUT = 1;

	// カメラ情報
	private Camera camera_object;
	private RaycastHit hit;

	// 成功フラグ
	//bool success = false;

	void Start()
	{
		// カメラ情報を取得
		camera_object = Camera.main;

		// 配列を初期化
		InitializeArray();

		// デバッグ用
		DebugArray();

        // 置く場所の自動生成
        {
            for (int z = 0; z < arrayHeight; z++)
            {
                for (int x = 0; x < arrayWidth; x++)
                {
					// 位置調整
                    Vector3 offset = new Vector3(1f, 0f, 0f);
                    Vector3 pos = new Vector3(x, 0, z ) + offset;
                    GameObject cell = Instantiate(gridCellPrefab, pos, Quaternion.identity);

                    GridCell gridCell = cell.GetComponent<GridCell>();
                    gridCell.gridX = x;
                    gridCell.gridZ = z;
                }
            }
        }

    }

    void Update()
	{
		// マウスがクリックされた時
		if (Input.GetMouseButtonDown(0))
		{
			// マウスのポジションを取得してRayに代入
			Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

			// マウスのポジションからRayを飛ばして何かに当たったらhitに入れる
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("TemporaryGrid"))
				{
					GridCell cell = hit.collider.GetComponent<GridCell>();
					//if (cell == null) return;

					int x = cell.gridX;
					int z = cell.gridZ;

					if (squares[z, x] == ENPTY)
					{
						squares[z, x] = PUT;

                        // ドーナツ生成
                        float donutHeight = donutObj.GetComponent<Renderer>().bounds.size.y;
                        Vector3 spawnPos = hit.collider.transform.position + Vector3.up * (donutHeight / 2f);
                        GameObject donut = Instantiate(donutObj, spawnPos, Quaternion.identity);

                        // ドーナツに位置情報を付与
                        GridCell donutCell = donut.AddComponent<GridCell>();
						donutCell.gridX = x;
						donutCell.gridZ = z;
						//donut.tag = "Donut";
						Debug.Log("ドーナツ生成");
					}
					else
					{
						Debug.Log("すでにドーナツあり");
					}

				}
                    // ドーナツをクリックした場合
                else if (hit.collider.CompareTag("Donut"))
                {
                    GridCell donutCell = hit.collider.GetComponent<GridCell>();
                    if (donutCell != null)
                    {
                        squares[donutCell.gridZ, donutCell.gridX] = ENPTY;
                    }

                    Destroy(hit.collider.gameObject);
                    Debug.Log("ドーナツ削除");
                }
            }
		}

		/*
		// パーティクルプレイ
		if (success == true)
		{
			Debug.Log("パーティクルプレイ");
			particle.Play();
		}
		else if (success == false)
		{ 
			Debug.Log("パーティクルストップ");
			particle.Stop();
		}
		*/
	}

	private void InitializeArray()
	{
		// 配列にアクセス
		for(int i = 0; i < arrayHeight; i++)
		{
			for(int j = 0; j < arrayWidth; j++)
			{
				// 配列を空にする
				squares[i, j] = ENPTY;
			}
		}
	}

	// デバッグ用
	private void DebugArray()
	{
		for (int i = 0; i < arrayHeight; i++)
		{
			for (int j = 0; j < arrayWidth; j++)
			{
				Debug.Log("(i,j) = (" + i + "," + j + ") = " + squares[i, j]);
			}
		}
	}
	
}

