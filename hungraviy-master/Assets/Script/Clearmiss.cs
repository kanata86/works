using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearmiss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            GameManager.SetState(GameState.GameOver);
        }
        else if(collision.CompareTag("Clear"))
        {
            GameManager.SetState(GameState.GameCler);
            var millsec = 123456;
            var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
        }
    }

}
