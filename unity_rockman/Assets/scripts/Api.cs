using UnityEngine;

public class Api : MonoBehaviour
{
    public Transform tra1;
    public Transform tra2;
    public SpriteRenderer spr;

    //1. 非靜態 API 需要物件
    //2. 定義一個欄位 -物件

    private void Start()
    {
        //靜態 API
        //類別名稱.靜態屬性
        float f = Random.value;
        //非靜態  API
        //物件名稱.非靜態屬性
        print("取得物件的座標" + tra1.position);
        tra2.localScale = new Vector3(3, 3, 3);

        spr.color = new Color(1, 0, 0);
        spr.flipX = true;
        
    }
    private void Update()
    {
        tra2.Translate(0.1f, 0, 0);
    }
}
