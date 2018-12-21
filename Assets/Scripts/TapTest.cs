using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class TapTest : MonoBehaviour {

    // メインカメラ
    private Camera mainCamera;

    // スプライトのプレハブ
    [SerializeField]
    private GameObject spritePrefab;

    // Use this for initialization
    void Start () {
        // タップジェスチャーの生成
        TapGestureRecognizer tapGesture = new TapGestureRecognizer();
        // 状態が変化したときに関数が呼ばれるように設定
        tapGesture.StateUpdated += TapGestureCallback;
        // フィンガースクリプトのマネージャに登録
        FingersScript.Instance.AddGesture(tapGesture);

        // メインカメラを取得
        mainCamera = Camera.main;
    }

    // タップの各種イベント時に実行されるコールバック関数
    private void TapGestureCallback(GestureRecognizer gesture)
    {
        // タップ成功？
        if (gesture.State == GestureRecognizerState.Ended)
        {
            Debug.Log(string.Format("Tapped at {0}, {1}",
gesture.FocusX, gesture.FocusY));
            CreateSprite(new Vector2(gesture.FocusX, gesture.FocusY));
        }
    }

    // スプライトを生成
    private void CreateSprite(Vector2 touchPos)
    {
        // タッチ座標をスクリーン座標系からワールド座標系に変換
        Vector2 worldpos = mainCamera.ScreenToWorldPoint(touchPos);
        // プレハブからゲームオブジェクトを生成
        Instantiate(spritePrefab, worldpos, Quaternion.identity);
    }
}
