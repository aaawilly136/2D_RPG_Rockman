using UnityEngine;

public class Apipractice : MonoBehaviour
{
    public Camera cam1;
    public SpriteRenderer spr1;
    public Transform tra;
    public Rigidbody2D rig;

    private void Start()
    {
        //取得非靜態屬性
        print("攝影機的深度" + cam1.depth);
        print("圖片1的顏色" + spr1.color);
        //取得非靜態屬性
        cam1.backgroundColor = new Color(1, 0.3F, 0.4F);
        spr1.flipY = true;
        
    }

    private void Update()
    {
        //使用非靜態方法
        
        tra.Rotate(0, 0, 1);
        rig.AddForce(new Vector2(0, 10));
    }
}
