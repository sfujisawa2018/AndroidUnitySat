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
        //                  X  Y    W     H
        //cam.rect = new Rect(0.5f, 0, 0.5f, 1.0f);
        // カメラのorthographicSizeを設定
        // 縦合わせ（縦サイズを計算）
        cam.orthographicSize = height / 2f / pixelPerUnit;
        if (match == Match.Height)
        {
            //// 縦合わせ（縦サイズを計算）
            //cam.orthographicSize = height / 2f / pixelPerUnit;
            // 描画領域の横幅割合を計算
            float viewportW = width * Screen.height / height / Screen.width;
            // 余白の割合を計算
            float blankW = 1.0f - viewportW;
            // 開始位置を余白の半分にする
            float viewportX = blankW/2.0f;
            // ビューポート領域の指定
            cam.rect = new Rect(viewportX, 0, viewportW, 1.0f);
        }
        else
        {
            //// 縦合わせ（縦サイズを計算）
            //cam.orthographicSize = height / 2f / pixelPerUnit;
            // 描画領域の縦幅割合を計算
            float viewportH = height * Screen.width / width / Screen.height;
            // 余白の割合を計算
            float blankH = 1.0f - viewportH;
            // 開始位置を余白の半分にする
            float viewportY = blankH / 2.0f;
            // ビューポート領域の指定
            cam.rect = new Rect(0, viewportY, 1.0f, viewportH);

            // 横合わせ（縦サイズを計算）
            //cam.orthographicSize = width / 2f / pixelPerUnit * aspectRatio;
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
