using UnityEngine;

public class Bullet : MonoBehaviour
{
    //碰撞事件
    //collision 指的是碰撞物件
    public float attack;
    private void Start()
    {
        // 讓子彈彼此不要互相碰撞
        Physics2D.IgnoreLayerCollision(10, 10, true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果 碰撞物件的標籤 等於敵人
        if (collision.gameObject.tag == "敵人")
        {
            // 取得 敵人 腳本 並呼叫 受傷方法
            collision.gameObject.GetComponent<Enemy>().Hit(attack);
            
        }
        //碰撞 對 任何物件都要刪除
        Destroy(gameObject);
    }
}
