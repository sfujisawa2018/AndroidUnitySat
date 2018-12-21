using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class SwipeTest : MonoBehaviour
{

    // メインカメラ
    private Camera mainCamera;

    // スプライトのプレハブ
    [SerializeField]
    private GameObject spritePrefab;

    // Use this for initialization
    void Start()
    {
        // スワイプジェスチャーの生成
        SwipeGestureRecognizer swipeGesture = new SwipeGestureRecognizer();
        // 上下左右どの方向でも反応するように設定
        swipeGesture.Direction = SwipeGestureRecognizerDirection.Any;
        // 状態が変化したときに関数が呼ばれるように設定
        swipeGesture.StateUpdated += SwipeGestureCallback;
        // スワイプ方向の角度を無視する設定（デフォルトは1.5f)
        swipeGesture.DirectionThreshold = 1.0f;
        // フィンガースクリプトのマネージャに登録
        FingersScript.Instance.AddGesture(swipeGesture);

        // メインカメラを取得
        mainCamera = Camera.main;
    }

    // スワイプの各種イベント時に実行されるコールバック関数
    private void SwipeGestureCallback(GestureRecognizer gesture)
    {
        SwipeGestureRecognizer swipeGesture = gesture as SwipeGestureRecognizer;

        // スワイプ成功？
        if (gesture.State == GestureRecognizerState.Ended)
        {
            CreateFlyingSprite(
new Vector2(gesture.StartFocusX, gesture.StartFocusY),
new Vector2(gesture.FocusX, gesture.FocusY)
);
            Debug.Log(
string.Format("Swiped from {0},{1} to {2},{3}; velocity: {4}, {5}", gesture.StartFocusX, gesture.StartFocusY,
gesture.FocusX, gesture.FocusY,
swipeGesture.VelocityX, swipeGesture.VelocityY));
        }
    }

    // 飛んでいくスプライトを生成
    private void CreateFlyingSprite(Vector2 startPosition, Vector2 endPosition)
    {
        // タッチ開始座標をスクリーン座標系からワールド座標系に変換
        Vector2 worldStartpos = mainCamera.ScreenToWorldPoint(startPosition);
        // タッチ終了座標をスクリーン座標系からワールド座標系に変換
        Vector2 worldEndpos = mainCamera.ScreenToWorldPoint(endPosition);

        // プレハブからゲームオブジェクトを生成
        GameObject spriteObj = Instantiate(
        spritePrefab, worldStartpos, Quaternion.identity);
        // スワイプの方向に適当な力を加える
        Vector2 force = worldEndpos - worldStartpos;
        force *= 100.0f;
        spriteObj.GetComponent<Rigidbody2D>().AddForce(force);
    }
}
