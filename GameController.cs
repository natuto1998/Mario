using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField]
    private Text TimeLimitText; //制限時間を表示させるテキスト
    [SerializeField]
    private Text StockText;     //残機を表示させるテキスト
    [SerializeField]
    private Text SheetsText;　　//コインを表示させるテキスト
    
    private int num = 0;
    private int Coin;      //コイン
    private int Stock = 5; //残機    
    private float Number;  //Secondsを入れるためのもの
    private Timer script; //Timerを入れるスクリプト
    private GameObject TimerObject;　//GameObjectの指定            

    void Start()
    {
        TimerObject = GameObject.Find("Display");   //GameObjectの指定
        script = TimerObject.GetComponent<Timer>(); //scriptにTimerを参照する          
    }
    void Update()
    {
        Number = script.GetNow(); //Numberの値をSecondsの値にする
        //GetComponent<Text>().text = ((int)Number).ToString();　//Inspector上のTextに反映させる
        TimeLimitText.text = ((int)Number).ToString(); //テキストに制限時間を表示させる
        SheetsText.text = Coin.ToString();　//テキストにコインの所持枚数を表示させる
        StockText.text = Stock.ToString();　//テキストに残機を表示させる        
        //Coin = GetCoin_Coin();
    }

    //残機が増えるときの処理
    public void LifeCountUp()
    {
        //残機が増えるアクションがあったら残機を1増やす 
        Stock += 1;

        //残機の値が99の時残機は増えない
        if (Stock == 99)
        {
            Stock = 99;
        }
    }

    //残機が減るときの処理
    public void LifeCountDown()
    {
        //残機が減るアクションがあったら残機を1減らす        
        Stock -= 1;
        GameRedo();

        //残機が0になったらGameOverにする　GameOverが呼び出されたら残機を5に戻す
        if (Stock == 0)
        {
            GameOver();
            Stock = 5;
        }
    }

    //コイン獲得時の処理
    public void GetCoin_Coin()
    {
        //コインの値を+1する
        Coin += 1;
        //SetCoin();
        Debug.Log("コインに触れた");

        //コインの値が99のときにコインを獲得した時コインの値を0にし残機を増やす関数を呼び出す
        if (Coin == 100)
        {
            Coin = 0;
            LifeCountUp();
        }
    }

    //Main画面に戻る
    public void GameRedo()
    {
        SceneManager.LoadScene("Main");
    }

    //GameStart画面に戻る
    public void GameOver()
    {
        SceneManager.LoadScene("GameStart");
    }
}
