using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
	private Vector3 mouse;		// マウスの位置
	private Vector3 target;		// オブジェクトのターゲットの位置

	void Updata()
	{
		// マウスの座標を取得する
		mouse = Input.mousePosition;

		// マウスの位置の確認
		Debug.Log(mousePos);

		// スクリーン座標をワールド座標に変換する
		target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10f));

		// ワールド座標をゲームオブジェクトの座標に設定
		this.transform.position = target;
	}
}
