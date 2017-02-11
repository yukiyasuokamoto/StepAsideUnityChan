using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
	//Unityちゃんのオブジェクト
	private GameObject unitychan;
	//破壊オブジェクトとUnityちゃんの距離
	private float difference;

	// Use this for initialization
	void Start () {
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");
		//Unityちゃんと破壊オブジェクトの位置（z座標）の差を求める
		this.difference = unitychan.transform.position.z - this.transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {
		//Unityちゃんの位置に合わせて破壊オブジェクトの位置を移動
		this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z-difference);

	}
	//トリガーモードで他のオブジェクトと接触した場合の処理
	void OnTriggerEnter(Collider other){
		Debug.Log ("トリガーモードで他のオブジェクトと接触した場合の処理");
		//障害物に衝突した場合
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag"||other.gameObject.tag == "CoinTag") {
			//接触したコインのオブジェクトを破棄
			Destroy (other.gameObject);

		}
	}
}
