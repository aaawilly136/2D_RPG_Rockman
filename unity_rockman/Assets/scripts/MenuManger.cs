using UnityEngine;
using UnityEngine.UI; //button
using UnityEngine.SceneManagement; //scencemanger使用場景管理器

public class MenuManger : MonoBehaviour
{
    
    //使用靜態方法處理 1.開始遊戲 2.離開遊戲
    //如何讓按鈕跟程式溝通
    //需要一個公開的方法
    private void Update()
    {
        //如果有綠色波浪(api版本過舊)則建議用新的方式來寫
        //如果按下esc則退出遊戲
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
                
        }
    }
    private void DelayStartGame()
    {
        //延遲呼叫("方法名稱" ,延遲時間)
        Invoke("DelayStartGame",1.1f);
    }
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void Gamestart()
    {
        SceneManager.LoadScene("遊戲畫面");
    }
    /// <summary>
    /// 離開遊戲
    /// </summary>
    private void Quitgame()
    {
        Invoke("DelayQuitgame", 1.1f);
    }
    
    public void DelayQuitgame()
    {

        Application.Quit();
    }

}
