using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour {
	private GameObject unitychan; //Unityちゃんのオブジェクト
	public GameObject CarPrefab; //carprefabを入れる
	public GameObject coinprefab; //coinprefabを入れる
	public GameObject coneprefab; //cornprefabを入れる
	private int startPos = -160; // 開始位置
	private int createdPos = -160; // 作成済みの位置（初期値はスタートと同じ)
	private float posRange=3.4f; //アイテムを出すX方向の範囲

	// Use this for initialization
	void Start () {
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");
	}
		void Update() {

			// Goalまでの間でUnity ちゃん + 40m が作成済みの位置より大きいくなったら1列生成
		if( unitychan.transform.position.z + 40 > createdPos &&unitychan.transform.position.z + 40 <130 ) {
				//どのアイテムを出すのかランダムに設定
				int num=Random.Range(0,10);
				if (num <= 1) {
					//コーンをx方向に一直線に生成
					for (float j = -1; j <= 1; j += 0.4f) {
						GameObject Cone = Instantiate (coneprefab)as GameObject;
					Cone.transform.position = new Vector3 (4 * j, Cone.transform.position.y, createdPos);
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
						coin.transform.position=new Vector3(posRange*J, coin.transform.position.y, createdPos+offsetZ);
						}else if(7<=item&&item<=9){
							//車を生成
							GameObject Car=Instantiate (CarPrefab) as GameObject;
						Car.transform.position=new Vector3(posRange*J,CarPrefab.transform.position.y,createdPos+offsetZ);
						}
					}
				}
				// 1列作ったので、15m進める
				createdPos += 15;
			}
		}
	}