using UnityEngine;

public class Knight : MonoBehaviour
{
    [Header("移動速度"), Range(0,1000)]
    public float speed = 10;
    [Header("等級 ")]
    [Range(1, 100)]
    public int LV = 1;

    /*
    物件資料 - 欄位語法
    類型 名稱 指定 預設值
    浮點數float 某某東西的浮動數值 例:float weight = (1,1000);,例:float weight =1.2f; 有小數點結尾要+f
    整數int 某某東西的整數數值 例: int cc = 1000;
    布林值bool 是否打開某某事件 例 :bool haswindow = true;
    字串string 某某東西的樣子
    關鍵字 顏色:藍色
    自訂名稱 顏色 :白色

    修飾詞
    私人: 不顯示 private(預設值)
    公開: 顯示 public 顯示在unity屬性面板

    欄位屬性語法
    [屬性名稱(屬性內容)]
    標題:[Header("內容")]
    題示:[ToolTip("這是汽車")]
    範圍 Range(最小值,最大值) 限定為數字類型
    
    */
    [Header("汽車的重量"), Tooltip("這是汽車的重量"), Range(1000,6000)]
    public int cc = 1000;

    float weight = 1.5f;

    [Header("汽車的品牌")]
    public string brand = "BMW";
    [Header("有沒有天窗")]
    public bool haswindow = true;

    // Unity 常見類型
    // 顏色 color
    // 維度 vector2 vector3 vector4

    public Color color;
    public Color red = Color.red;
    public Color myColor = new Color(0.3f, 0, 0.6f); // color(紅，綠，藍)
    public Color Mycolor2 = new Color(0, 0.5f, 0.5f, 0.5f); //color(紅，綠，藍，透明)
    private void Start()
    {
        // 初始設定
    }

    private void Update()
    {
        // 持續執行
    }
}
