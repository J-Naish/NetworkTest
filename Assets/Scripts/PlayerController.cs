using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // アニメーション用変数
    [SerializeField] private Animator animator;

    // CharacterControllerを取得
    private CharacterController characterController;

    // 移動に用いる変数
    private Vector3 moveDirection;

    // 移動速度係数
    [SerializeField]
    private float moveVelocity = 80.0f;


    void Start()
    {
        // CharacterControllerを取得
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        // キャラが移動する関数
        MoveByKey();
    }



    // 十字キーで移動する関数
    private void MoveByKey()
    {
        animator.SetFloat("MoveSpeed", moveDirection.magnitude);

        // キャラクターの移動
        // *暫定的に十字キーで移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection += transform.right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection -= transform.right;
        }
        // キーが押されてなければ移動しない
        if (!Input.anyKey)
        {
            moveDirection = Vector3.zero;
        }

        // ベクトルを正規化
        moveDirection.Normalize();

        // 移動方向にカメラを向ける
        transform.LookAt(transform.position + moveDirection);

        // Playerを移動させる
        characterController.Move(moveDirection * moveVelocity * Time.deltaTime);
    }


}