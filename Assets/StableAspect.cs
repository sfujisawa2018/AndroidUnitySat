using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour {

    // フィールド
    private Camera cam;
    // 画像のサイズ
    public float width = 1334f;
    public float height = 750f;
    // 画像のPixel Per Unit
    public float pixelPerUnit = 100f;

    // 合わせる方向
    public enum Match
    {
        // 縦に合わせる
        Height,
        // 横に合わせる
        Width
    };

    // 合わせる方向
    public Match match;

    // 起動時に実行される
    private void Awake()
    {
        // アスペクト比の計算
        float aspectRatio = (float)Screen.height / (float)Screen.width;
        // カメラコンポーネントを取得
        cam = GetComponent<Camera>();
        // カメラのorthographicSizeを設定
        if (match == Match.Height)
        {
            // 縦合わせ（縦サイズを計算）
            cam.orthographicSize = height / 2f / pixelPerUnit;
        }
        else
        {
            // 横合わせ（縦サイズを計算）
            cam.orthographicSize = width / 2f / pixelPerUnit * aspectRatio;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //// アスペクト比の計算
        //float aspectRatio = (float)Screen.height / (float)Screen.width;
        //// カメラコンポーネントを取得
        //cam = GetComponent<Camera>();
        //// カメラのorthographicSizeを設定
        ////cam.orthographicSize = height / 2f / pixelPerUnit;
        //// 縦サイズ
        //cam.orthographicSize = width / 2f / pixelPerUnit * aspectRatio;
    }
}
