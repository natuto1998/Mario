using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
    
    [SerializeField]
    private Sprite Non_Destructive;  //破壊できないブロック 

    private SpriteRenderer MainSpriteRenderer; //画像の選択    
    private GameObject Child;  //ブロックから出したいもの
    private bool i = false;    //制御
    private float Speed = 0.03f;
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Child = transform.Find("Kinoko").gameObject;
    }
	
	void Update () {
        
    }

    private void BlockProcessing()
    {
        //キャラクターがジャンプして下から、強着地で上から、甲羅状態で移動している物が横から触れたとき
            //消える
            //アイテムが出る

            //消えず画像が変更される
    }

    //プレイヤーが触れた時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mario")
        {
            MainSpriteRenderer.sprite = Non_Destructive;
            if (!i)
            {
                Child.SetActive(true);                
                i = true;
            }            
        }
        //当たり判定の獲得
        ContactPoint2D contact = collision.contacts[0];
        Vector2 pos = contact.point;
        Debug.Log(pos);
    }
}
