using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	//carprefabを入れる
	public GameObject CarPrefab;
	//coinprefabを入れる
	public GameObject coinprefab;
	//cornprefabを入れる
	public GameObject coneprefab;
	//スタート地点
	private int startsPos=-160;
	//ゴール地点
	private int goalPos=120;
	//アイテムを出すX方向の範囲
	private float posRange=3.4f;


	// Use this for initialization
	void Start () {
		//一定の距離ごとにアイテムを生成
		for(int i=startsPos;i<goalPos;i+=15){
			//どのアイテムを出すのかランダムに設定
			int num=Random.Range(0,10);
			if (num <= 1) {
				//コーンをx方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject Cone = Instantiate (coneprefab)as GameObject;
					Cone.transform.position = new Vector3 (4 * j, Cone.transform.position.y, i);
				}
			}else{
				//レーンごとにアイテムを生成
				for(int J=-1;J<2;J++){
					//アイテムの種類を決める
					int item=Random.Range(1,11);
					//アイテムをおくZ座標のオフセットをランダムに設置
					int offsetZ=Random.Range(-5,6);
					//60%コイン配置：30%車配置:10%何もなし
					if(1<=item&&item<=6){
						//コインを生成
						GameObject coin=Instantiate(coinprefab)as GameObject;
						coin.transform.position=new Vector3(posRange*J, coin.transform.position.y, i+offsetZ);
					}else if(7<=item&&item<=9){
						//車を生成
						GameObject Car=Instantiate (CarPrefab) as GameObject;
						Car.transform.position=new Vector3(posRange*J,CarPrefab.transform.position.y,i+offsetZ);
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
