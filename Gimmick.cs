using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gimmick : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    private void ClayPipe()
    {
        //土管に入るときの処理
        
    }

    private void Waypoint()
    {
        //キャラクターがここに触れたらMainの場所をここに変更する
    }

    private void Goal()
    {
        //キャラクターがここに触れたらMainの場所を一番最初に戻す

        //キャラクターが触れた部分が天辺ならGameControllerのLifeCountUpを呼び出す
    }

    //オブジェクトが触れている間   
    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Mario")
        {
            Debug.Log("マリオ");
            if (Input.GetKey("s"))
            {
                Debug.Log("土管");
                //SceneManager.LoadScene("DokanIn");
            }
        }
    }  
}
