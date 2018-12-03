using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    private float Seconds = 300.0f;
    private bool GameOver = false;       

    //※どんな変数が必要になるのか
    //※カウントダウン
    //※カウントアップ
    void Update()
    {
        TimerCount();        
    }

    // 1フレームにかかった時間を減らすまたは増やす
    private void TimerCount()
    {       
        if (GameOver == false)
        {            
            Seconds -= Time.deltaTime;
            if (Seconds < 0)
            {
                //GameOverにする 
                GameOver = true;
                Debug.Log((int)Seconds);
            }
        }
    }

    public float GetNow() { return Seconds; }

    // いらなくなりそう。。。時間をテキストに反映させる        
}

