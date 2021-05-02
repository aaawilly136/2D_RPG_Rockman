using UnityEngine;

public class car : MonoBehaviour
{
    #region 事件
    public int number = 1;
    public bool test = false;
    public string prop = "紅色藥水";
    // 事件:在特定時間點會被執行的方法
    // unity 提供的事件:開始、更新

    // 開始事件執行時間點與次數: 播放遊戲後執行一次
    // 應用: 數值初始化，例如:遊戲一開始多少金幣或生命值等..

    private void Start()
    {
        //print(任何資料)-輸出資料到console 儀表板上
        print("我是開始事件啾咪~");

        // 欄位存取
        // 取得
        // 語法: 欄位名稱
        // 字串串接: 字串 + 其他欄位
        print("取得欄位 : " +number);

        // 存放
        // 語法:欄位名稱 指定 值;
        // 值必須與此欄位類型相同;
        test = true;
        print("存放欄位後的結果" + test);

        prop = "藍色藥水";
        print("存放後的道具名稱" + prop);
        //* 呼叫方法
        // 方法名稱();
        Test();
        

        // 傳回方法:
        // 傳回類型 名稱 = 傳回方法();
        int t = Ten();
        print("傳回方法的結果" + t);

    }

    // 更新事件執行時間點與次數:開始事件後以每秒約六十次執行 60fps
    // 應用:監聽玩家輸入與物件持續行為，例如 :玩家有沒有按按鈕或讓物件持續移動

    private void Update()
    {
        print("我是更新事件!!");
    }
    #endregion
    #region 方法
    // 方法:保存較複雜的演算法的程式區塊
    // 語法:
    // void 無傳回 :使用這個方法不會有傳回
    // 方法需要被【呼叫】才會執行
    /// <summary>
    /// 我是一個測試方法
    /// </summary>
    private void Test()
    {
        print("我是測試方法。" );
    }

    // 如果不是無傳回，在大括號內必須使用 傳回 return 值(必須跟傳回類型相同)
    /// <summary>
    /// 這是傳回整數10的方法
    /// </summary>
    /// <returns>整數十</returns>
    private int Ten()
    {
        return 10;
    }
    #endregion

}