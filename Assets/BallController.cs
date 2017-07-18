using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	
	// ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;
	// ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// 得点を表示するテキスト
	private GameObject totalpointText;
	// 合計得点
	private int totalPoint = 0;
	// SmallStarオブジェクトに衝突した時に取得できる得点
	private int smallstarPoint = 10;
	// LargeStarオブジェクトに衝突した時に取得できる得点
	private int largestarPoint = 20;
	// SmallCloudオブジェクトに衝突した時に取得できる得点
	private int smallcloudPoint = 30;
	// LargeCloudオブジェクトに衝突した時に取得できる得点
	private int largecloudPoint = 40;

	// Use this for initialization
	void Start () {
		// シーン中のGameOverTextオブジェクトとTotalPointTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.totalpointText = GameObject.Find ("TotalPointText");
	}
	
	// Update is called once per frame
	void Update () {
		// ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			// GameOverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	// 衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		// 衝突したオブジェクトによって、得点を加算
		if (other.gameObject.tag == "SmallStarTag") {
			totalPoint += smallstarPoint;
		} else if (other.gameObject.tag == "LargeStarTag") {
			totalPoint += largestarPoint;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			totalPoint += smallcloudPoint;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			totalPoint += largecloudPoint;
		}
		// TotalPointTextに合計得点を表示
		this.totalpointText.GetComponent<Text> ().text = totalPoint.ToString() + "点";
	}
}
