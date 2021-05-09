using UnityEngine;
using UnityEditor.Animations;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"),Range(0,2000)]
    public float Speed = 10.5f;
    [Header("跳越高度"),Range(0,3000)]
    public int JumpHeight = 100;
    [Header("血量"), Range(0, 200)]
    public float HP = 100;
    [Header("角色是否在地板上"), Tooltip("儲存角色是否在地板上")]
    public bool isGround;
    [Header("子彈"), Tooltip("角色要發射的子彈遊戲物件")]
    public GameObject bullet;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    [Header("子彈生成點"), Tooltip("子彈生成點位置")]
    public Transform bulletpoint;
    [Header("開槍音效"), Tooltip("開槍的音效")]
    public AudioClip bulletSound;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    #endregion
    #region 事件

   
    private void Start()
    {

        //利用程式取得元件
        //傳回元件 取得元件<元件名稱>() -<泛型>
        rig = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();


    }
    #endregion
    #region 方法
    private void Update()
    {
        Move();
        Jump();
    }
    //繪製圖示 - 輔助編輯時的圖形線條
    private void OnDrawGizmos()
    {
        //1.指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //2.繪製圖形
        Gizmos.DrawSphere(Vector3.zero, 0.5f);
        
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="speed">移動速度</param>
    /// <param name="sound">聲音</param>
    public void Move()
    {
        //1. 要抓到玩家按下左右鍵的資訊 input
        //2. 使用左右鍵的資訊控制角色移動
        
        float h = Input.GetAxis("Horizontal");
        //剛體.加速度 = 二維向量(水平*速度*一幀的時間,0,rig.velocity.y指定回原本y軸加速度)
        //一幀的時間 解決不同效能的裝置速度差的問題 Time.deltaTime 1/60次
        rig.velocity = new Vector2(h * Speed * Time.deltaTime, rig.velocity.y);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    /// <param name="height">跳躍高度</param>
    /// <param name="sound">跳躍踏地聲</param>
    public void Jump()
    {
        //如果 玩家 按下空白鍵就跳躍
        //判斷式 c#
        //傳回值為布林值的方法可以當作布林值使用
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            float J = Input.GetAxis("Vertical");
            rig.AddForce(new Vector2(0, JumpHeight));
        }
        
    }
    /// <summary>
    /// 開槍
    /// </summary>
    /// <param name="speed">射擊速度</param>
    /// <param name="sound">開槍聲音</param>
    public void Shoot(float speed, string sound = "嘣")
    {
        print("射擊速度" + speed);
        print("開槍聲音" + sound);
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="mideductionhp">造成傷害</param>
    /// <param name="sound">受傷聲音</param>
    public void Hurt(float mideductionhp,string sound = "阨阿")
    {
        print("扣的血量" + mideductionhp);
        print("受傷的聲音" + sound);
    }
    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool Die()
    {
        return false;
    }
    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="prop">道具名稱</param>
    private void Eatitem(string prop)
    {
        print("取得道具");
    }




    #endregion




}
