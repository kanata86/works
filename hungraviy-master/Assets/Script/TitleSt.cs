using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSt : MonoBehaviour
{



    public void GameStart()
    {
       
        SceneManager.LoadScene("Stage1Time");
    }
    public void ButtonClicked()
    {
        SceneManager.LoadScene("sousasetumei");
    }

}	
	

