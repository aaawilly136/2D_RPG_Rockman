using UnityEngine;

public class apistatic : MonoBehaviour
{
    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(22, 22, 22);
    //認識靜態api
    //包含關鍵字 static 就是靜態
    private void Start()
    {
        //屬性 欄位 要知道如何存取
        //練習取得靜態屬性 static properties
        //語法
        //類別名稱.靜態屬性名稱
        float r = Random.value;
        print("隨機值 :"+r);

        // 練習存放靜態屬性static properties
        // 有顯示read only 的屬性不能存放
        // 語法
        // 類別名稱.靜態屬性名稱 指定 值;
        Cursor.visible = false;          //指標.可見度
        
        // 練習使用靜態的方法 static methods
        // 語法
        // 類別名稱.靜態方法(對應的參數);
        int attack = Random.Range(100,300);
        print("隨機攻擊力" + attack);

        float n = Mathf.Abs(-99.9f);
        print("絕對值" + n);

        print("攝影機數量:" + Camera.allCamerasCount);

        Physics2D.gravity = new Vector2(0, -20f);
        print("重力:" + Physics2D.gravity);

        //Application.OpenURL("https://unity.com/");
        //float f = Mathf.Floor(9.999f);
        //print("去小數點的結果:" +f);

        float dis = Vector3.Distance(a, b);
        print("a與b的距離" + dis);

   
        
    }

    private void Update()
    {
        #region 練習
        //print("如果按下任意鍵:" + Input.anyKeyDown);
        //print("遊戲時間:" + Time.time);

        bool b = Input.GetKeyDown("space");
        print("是否按下任意鍵:" + b);
        #endregion

    }

}
