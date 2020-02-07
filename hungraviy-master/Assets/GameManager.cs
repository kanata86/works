using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//ゲーム開始のカウントダウン
//ゲーム中
//ゲームオーバー
//クリア
/// <summary>
//パブッリクのインテジャー型でステージを指定する
//パブリックのConstのインテジャー型でステージマックスという名前のステージを作る
//パブリックのスタティックのsetstate(引数で)
//https://www.sejuku.net/blog/50547
/// </summary>



public enum GameState 
{
    none,     //空のオブジェクト
    GameCler, //ゲームクリア
    GameOver, //ゲームオーバー   
    GameCount,//ゲーム開始のカウントダウン  
    GameCh,   //ゲーム中 
   
} 






public class GameManager : MonoBehaviour {

    public static GameState state=GameState.none;
     static GameState nextstate=GameState.GameCount;
    public GameObject GameOverObject;
    public GameObject ClaerObject;
    public int Stage = 1;  
    public const int StageCount = 3;
    public static bool CanMove
    {
        get
        {
            return state == GameState.GameCh;
        }
    }

    // Use this for initialization
    void Start () {

        nextstate = GameState.GameCount;
        state = GameState.none;

	}
    
	public static void SetState(GameState st)
    {
        if (st == GameState.GameOver || st == GameState.GameCler)
        {
            if(state!= GameState.GameCh)
            {
                return;
            }
        }
        nextstate = st;
       
    }

    // Update is called once per frame
    void Update() {
        
        
        if (nextstate != GameState.none)
        {
            state = nextstate;
            switch (state)
            {
                case GameState.GameCount:
                    
                    break;
                case GameState.GameOver:
                    GameOverObject.SetActive(true);
                    break;
                case GameState.GameCler:
                    ClaerObject.SetActive(true);
                    break;



            }

        }


        switch (state)
        {
            case GameState.GameCount:
                state = GameState.GameCh;
                break;
            case GameState.GameOver:
              if(Input.GetMouseButtonDown(0))
               {
                    SceneManager.LoadScene("Title");
               }
                break;
                             
            case GameState.GameCler:
                if (!Input.GetMouseButtonDown(0))
                    break;
                    string sname = "Stage";
                
                if (Stage < StageCount)
                {
                    sname += (Stage + 1);
                    
                }
                else
                {
                    sname = "Ending";
                }
                SceneManager.LoadScene(sname);
                break;
                

        }


	}
}
