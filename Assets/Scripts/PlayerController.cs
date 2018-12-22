using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // 水平方向入力を取得
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        // 垂直方向入力を取得
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        // 位置を動かす
        //transform.position += new Vector3(x, y, 0) * 0.03f;
        rigidbody.AddForce(new Vector2(x, y) * 2.0f);

        // ジャンプボタンを押したら
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            // 重力がかかるようになる
            rigidbody.gravityScale = 1.0f;
            // 上方向に押し出す
            rigidbody.AddForce(new Vector2(0, 500));
        }

        // ファイアボタンを押したら
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            // 右方向に押し出す
            rigidbody.AddForce(new Vector2(500, 0));
        }
    }
}
