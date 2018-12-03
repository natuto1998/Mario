using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 Scale;
    private float Speed = 0.03f; //キャラクターの移動の速さ

    void Start()
    {
        Scale = transform.localScale;
    }

    void FixedUpdate()
    {
        Enemy_Move();
    }

    //３つとも別々の処理にする
    //エネミーの移動
    private void Enemy_Move()
    {
        //左に直進に移動
        transform.position += transform.right * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //エネミーが壁に当たったら移動方向を逆にする
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Kuribo" || collision.gameObject.tag == "Nokonoko") //Wallは壁
        {
            Speed *= -1;
            Scale.x *= -1;
        }
        transform.localScale = Scale;        
    }
}


