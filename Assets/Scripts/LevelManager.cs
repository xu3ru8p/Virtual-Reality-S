using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene("000");
    }

    public void StartTest03()
    {
        SceneManager.LoadScene("test03UI");
    }

  

    public void BeginGame()
    {
        SceneManager.LoadScene("001");
    }

    public void NoGuide()
    {
        SceneManager.LoadScene("no_guide");
    }

    public void HalfGuide()
    {
        SceneManager.LoadScene("half_guide");
    }


    public void OnExitGame()//定义一个退出游戏的方法
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//如果是在unity编译器中
#else
        Application.Quit();//否则在打包文件中
#endif
    }
} 

    

    

