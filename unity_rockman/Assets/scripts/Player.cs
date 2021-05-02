using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"),Range(0,1000)]
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
        Move(200, sound: "踏地聲");
        Jump(100, sound: "踏地聲大");
        Shoot(20);
        bool dead = Die();
        print("死亡為" +dead);
        Hurt(10);
        
        

    }
    #endregion
    #region 方法
    private void Update()
    {
        
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="speed">移動速度</param>
    /// <param name="sound">聲音</param>
    public void Move(float speed,string sound="踏地聲")
    {
        print("角色移動速度" + speed);
        print("角色移動聲音" + sound);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    /// <param name="height">跳躍高度</param>
    /// <param name="sound">跳躍踏地聲</param>
    public void Jump(int height,string sound="踏地聲大")
    {
        print("角色跳躍高度" + height);
        print("角色跳躍聲音" + sound);
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
