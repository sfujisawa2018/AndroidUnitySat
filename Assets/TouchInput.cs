using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    // フィールド
    // テキストコンポーネント
    private Text textComponent;

	// Use this for initialization
	void Start () {
        // テキストコンポーネントを取得
        textComponent = GetComponent<Text>();
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
                if (touch.phase == TouchPhase.Began)
                {

                }

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        text = "Began";
                        break;
                    case TouchPhase.Moved:
                        text = "Moved";
                        break;
                    case TouchPhase.Stationary:
                        text = "Stationary";
                        break;
                    case TouchPhase.Ended:
                        text = "Ended";
                        break;
                    case TouchPhase.Canceled:
                        text = "Canceled";
                        break;
                }
                // 文字列の末尾に付け足す　　　　　　　　　　　　　　　　　　　　　改行コード
                //text += "touch" + touch.fingerId + ":(" + touch.deltaTime + ")" + "\n";
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
