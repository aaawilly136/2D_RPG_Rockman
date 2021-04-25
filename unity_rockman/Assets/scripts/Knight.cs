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

    [Header("汽車的品牌")]
    public string brand = "BMW";
    [Header("有沒有天窗")]
    public bool haswindow = true;

    /* Unity 常見類型
    顏色 color
    維度 vector2 vector3 vector4
    */
    public Vector2 v2;
    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2my = new Vector2(7, 9);

    public Vector3 v3 = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4); //4筆資料

    public Color color;
    public Color red = Color.red;
    public Color myColor = new Color(0.3f, 0, 0.6f); // color(紅，綠，藍)
    public Color Mycolor2 = new Color(0, 0.5f, 0.5f, 0.5f); //color(紅，綠，藍，透明)

    /*
     按鍵 KeyCode
    */
    public KeyCode key1; // 不指定為 none(無)
    public KeyCode key2 = KeyCode.A;
    public KeyCode key3 = KeyCode.Mouse0; //左鍵0 右鍵1 滾輪2
    public KeyCode key4 = KeyCode.Joystick1Button0;
    /* 遊戲物件與元件
    遊戲物件 GameObject
    可以儲存任何包含 GameObject的物件
    */
    public GameObject obj1;
    public GameObject obj2;
    // 元件 Component

    public Transform tra; //可以儲存任何包含Transform
    public SpriteRenderer spr; //可以儲存任何包含SpriteRenderer
    private void Start()
    {
        // 初始設定
    }

    private void Update()
    {
        // 持續執行
    }
}
