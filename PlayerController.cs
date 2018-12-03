using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; //rdにキャラを入れる  
    [HideInInspector]
    public int Life = 1;    // 変数の初期化(ライフをここで設定)     
    [SerializeField]
    private GameObject Player;

    private bool Jp = true; //falseの間はジャンプができるようにする       
    private float Speed = 0.1f; //キャラクターの移動の速さ  
    private Vector2 Scale;  //プレイヤーの向きを変える
    private bool a = false; //プレイヤーの向きを変える    
    private Camera cam;     //メインカメラを取得
    private float x;   

    void Start()
    {
        Scale = transform.localScale;
        cam = Camera.main;
        Player = GameObject.Find("Mario");        
    }

    void FixedUpdate()
    {
        Player_move();
        Damage();
        Transform myTransform = this.transform;
    }

    //プレイヤーの移動の処理
    private void Player_move()
    {
        if (Input.GetKey("t"))
        {
            Vector2 tmp = GameObject.Find("Mario").transform.position;
            Debug.Log(tmp);
        }

        //カメラと移動
        if (transform.position.x > 0)
        {
            cam.transform.position = new Vector3(Player.transform.position.x, 0, -1);
        }       

        //右矢印キーを押したらキャラクターの向きを右側にし右に移動        
        if (Input.GetKey("d"))
        {
            //向きを変更する
            if (a == true)
            {
                Scale.x *= -1;
                a = false;
            }
            transform.localScale = Scale;

            //キャラクターを移動する
            transform.position += transform.right * Speed;
        }

        //右矢印キーを押したらキャラクターの向きを左側にし左に移動
        if (Input.GetKey("a"))
        {
            //向きを変更する
            if (!a)
            {
                Scale.x *= -1;
                a = true;
            }
            transform.localScale = Scale;

            //キャラクターを移動する
            transform.position += transform.right * -Speed;
        }

        //スペースキーを押したらジャンプ 
        if (!Jp && Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(0, 12.5f);
            Jp = true;
        }

        //シフトキーを押しながら移動すると加速   
        if (Jp == false)
        {
            if (!Jp && Input.GetKey("left shift"))
            {
                Speed = 0.2f;
            }
            else if (Input.GetKeyUp("left shift"))
            {
                Speed = 0.1f;
            }
        }        
        //ジャンプ中に下矢印キーを押したら急落下(ヒップドロップ)

        //加速しているときにジャンプすると強ジャンプ
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //コインに触れたコインの枚数が増える             
        if (collision.gameObject.tag == "Coin") //Coinはコイン
        {
            Destroy(collision.gameObject);
            GameController.Instance.GetCoin_Coin();
            //※ここを一回呼んだらいいようにする
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {                          
        //床に触れているときはJpをfalseにする
        if (collision.gameObject.tag == "Scaffold" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Dokan") //Scaffoldは床
        {
            Jp = false;
        }        

        //アイテムの獲得処理
        //キャラクターがアイテムに触れた時の処理

        //スーパーキノコに触れたならライフを2する
        if (collision.gameObject.tag == "Kinoko")
        {
            Destroy(collision.gameObject);
            if (Life == 1)
            {
                Scale *= 1.1f;
            }
            Life = 2;
            Debug.Log("Lifeは" + Life + "になりました");
        }

        //ノコノコに当たった時の処理
        if (collision.gameObject.tag == "Attack")
        {            
            Destroy(collision.gameObject);
            Debug.Log("触れた");
        }

        //ファイアフラワーに触れたならライフを3にする

        //スター        

        //1UPキノコに触れたならGameControllerのLifeCountUpを呼び出す

        //ダメージ判定時のキャラクターの大きさを変更
        if (collision.gameObject.tag == "Nokonoko")
        {
            Debug.Log("ノコノコに触れた");
            if (Life > 1)
            {
                Scale /= 1.1f;
            }
            Life -= 1;
        }

        if (collision.gameObject.tag == "Death")
        {
            Life = 0;
        }
    }    

    //ダメージの処理
    public void Damage()
    {
        //ライフが0になるとGameControllerのLifeCountDownを呼び出す
        if (Life == 0)
        {
            GameController.Instance.LifeCountDown();
        }
    }

    //落下の処理
    public void Falling()
    {
        //キャラクターが地面から落下したならスタート画面に戻りGameControllerのLifeCountDownを呼び出す
    }
}
