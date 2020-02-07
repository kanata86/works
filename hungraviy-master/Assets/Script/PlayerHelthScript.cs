using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelthScript : MonoBehaviour
{
    public float DamageTime = 2;
    float LastDamageTime = 0;
    public int PlayerHP;
    public GameObject[] PlayerIcon;
    public int destroyCount = 0;
    private new Renderer renderer;

    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        Debug.Log("PlayerHelth");
        LastDamageTime = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }
    void OnTriggerEnter2D(Collider2D other)//衝突判定
    {
        if (!GameManager.CanMove)
        {
            return;
        }
        //もしぶつかった相手にTag"Enemy"がついていたら
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(Time.time-LastDamageTime<DamageTime)
            {
                return;
            }
            if(GameManager.state!= GameState.GameCh)
            {
                return;
            }
            //HPを-1する
            PlayerHP -= 1;
            LastDamageTime = Time.time;

            //ノックバック
            float s = 200f * Time.deltaTime;
            transform.Translate(Vector2.left * s);

            StartCoroutine("Damage");

            //HPが0になったら
            if (PlayerHP == 0)
            {
                //破壊されたカウントを1増やす
                destroyCount += 1;
                if (destroyCount >= PlayerIcon.Length)
                {
                    GameManager.SetState(GameState.GameOver);
                }
                renderer.enabled = false;
               //this.gameObject.SetActive(false);

                //void UpdateIcon()を動かすために必要
                UpdatePlayerIcon();
                //void Retry()を動かすために必要
                Retry();
            }
        }
    }
    void UpdatePlayerIcon()//Playerの残基数のアイコンの制御
    {
        for (int i = 0; i < PlayerIcon.Length; i++)
        {
            if (destroyCount <= i)
                PlayerIcon[i].SetActive(true);
            else
                PlayerIcon[i].SetActive(false);
        }
    }

    void Retry()//PlayerのHpが0になったとき-ではなく初期値に戻す
    {
        //this.gameObject.SetActive(true);
        renderer.enabled = true;
        //プレイヤーのHP数
        PlayerHP = 1;

        StartCoroutine("Damage");//コルーチンDamege()を動かす為のもの
    }
    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        /*gameObject.layer = LayerMask.NameToLayer("PlayerDamage");*/
        //while文をループ
        int count = 6;

        while (count > 0)
        {
            //透明にする
            renderer.enabled = false;
            //0.05秒待つ
            yield return new WaitForSeconds(0.1f);
            //元に戻す
            renderer.enabled = true;
            //0.05秒待つ
            yield return new WaitForSeconds(0.1f);
            count--;
        }

        //レイヤーをPlayerに戻す
        /*gameObject.layer = LayerMask.NameToLayer("Player");*/
    }
}
