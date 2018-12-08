using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    // フィールド
    // テキストコンポーネント
    private Text textComponent;

    // メインカメラ
    private Camera cam;

    // プレハブ
    public GameObject prefabHorie;

	// Use this for initialization
	void Start () {
        // テキストコンポーネントを取得
        textComponent = GetComponent<Text>();
        // メインカメラを取得
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        // 一か所以上のタッチ情報あり？
		if (Input.touchCount > 0)
        {
            // 空白の文字列を作る
            string text = "";
            // タッチの数分だけ、一点ずつ処理していく
            foreach(Touch touch in Input.touches)
            {
                // タッチ座標をスクリーン座標系からワールド座標系に変換
                Vector2 worldpos = cam.ScreenToWorldPoint(touch.position);

                // タッチ開始の瞬間のみ
                if (touch.phase == TouchPhase.Began)
                {
                    // プレハブを複製して配置
                    Instantiate(prefabHorie, worldpos, Quaternion.identity);
                }

                // 文字列の末尾に付け足す　　　　　　　　　　　　　　　　　　　　　改行コード
                text += "touch" + touch.fingerId + ":(" + worldpos.x + "," + worldpos.y + ")" + "\n";
            }
            // 文字列をテキストコンポーネントに反映させる
            textComponent.text = text;
        }
        else
        {
            textComponent.text = "No touch";
        }
	}
}
