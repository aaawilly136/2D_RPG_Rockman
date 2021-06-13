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
    [Header("開槍音效"), Tooltip("開槍的音效")]
    public AudioClip bulletSound;
    [Header("判斷地板碰撞的位移與半徑")]
    public Vector3 groundoffest;
    public float groundRadius = 0.2f;
    [Header("子彈生成位置")]
    public Vector3 posBullet;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private ParticleSystem ps;

  
    #endregion
    #region 事件

   
    private void Start()
    {

        //利用程式取得元件
        //傳回元件 取得元件<元件名稱>() -<泛型>
        //取得跟此腳本同一層的元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        // 粒子系統 = 變形元件.搜尋子物件("子物件名稱")
        ps = transform.Find("集氣").GetComponent<ParticleSystem>();


    }
    #endregion
    #region 方法
    private void Update()
    {
        Move();
        Jump();
        Fire();
        // 2D 物理.忽略圖層碰撞(圖層1 ,圖層2 ,是否要忽略)
        Physics2D.IgnoreLayerCollision(9, 10, true);
    }
    //繪製圖示 - 輔助編輯時的圖形線條
    private void OnDrawGizmos()
    {
        //1.指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //2.繪製圖形
        // trasform 可以抓到此腳本同一層的變形元件
        Gizmos.DrawSphere(transform.position+ transform.right * groundoffest.x + transform.up * groundoffest.y +groundoffest,groundRadius);
        // 先指定顏色在畫圖型
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position + transform.right * posBullet.x + transform.up * posBullet.y, 0.1f);
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
        //如果按下D面向右邊
        //否則 如果按下A面向左邊
        if ((Input.GetKeyDown(KeyCode.D))||(Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.eulerAngles = Vector3.zero;
        }
        // 否則如果 按下a鍵時面相左邊 -0, 180, 0
        else if ((Input.GetKeyDown(KeyCode.A))||(Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // 設定動畫
        // 水平值不等於 零 布林值 打勾
        // 水平值等於 零 布林值 取消
        // 不等於符號寫法 != *(驚嘆號跟等於中間不能有空格)
        ani.SetBool("走路開關", h != 0);   
    }
    /// <summary>
    /// 紀錄按下左鍵的計時器
    /// </summary>
    private float timer;
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
        // * 判斷布林值是否等於true
        //1. isGround==true(原本寫法)
        //2. isGround (簡寫)
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            float J = Input.GetAxis("Vertical");
            rig.AddForce(new Vector2(0, JumpHeight));
            ani.SetTrigger("跳躍觸發");
        }
        //碰到的物件= 2d 物理.覆蓋圓形(中心點、半徑、1<<圖層編號(圖層))
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundoffest.x + transform.up * groundoffest.y , groundRadius,1 <<8);
        // 測試print("碰到的物件 " + hit.name);

        //如果碰到的物件存在並且碰到的物件名稱等於地板 就代表在地板上
        //並且符號 && (shift+7)
        //等於符號 == (此== 非= ，兩種等於是不一樣的)
        //或者符號 || (shift + \\)
        // (if+tab鍵會自動幫你寫出語法)
        //或者名稱等於跳台
        if (hit && (hit.name == "地板" || hit.name=="跳台"))
        {
            //print("角色在地板上");
            isGround = true;
        }
        //否則 不在地板上
        //否則 else
        //語法:else{程式區塊} - 僅能寫在if下方 要不然會出錯
        else
        {
            isGround = false;
        }
    }
    /// <summary>
    /// 開槍
    /// </summary>
    /// <param name="speed">射擊速度</param>
    /// <param name="sound">開槍聲音</param>
    public void Fire()
    {
        // 如果玩家按下左鍵就開槍 - 動畫與音效 發射子彈
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("攻擊觸發");
            ps.Play();
        }
        // 否則如果
        // else if (布林值) {程式區塊}
        // 按住左鍵
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            // 累加 +=
            timer += Time.deltaTime;
            //print("按住左鍵的時間" + timer);
        }
        // 放開左鍵
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ps.Stop();  //停止集氣
            aud.PlayOneShot(bulletSound, 0.5f);
            // Object.Instantiate(bullet); //原始寫法
            // Instantiate //簡寫
            // 暫存物件 = 生成(物件.座標.角度)
            // Quaternion 四位元-角度
            // Quaternion.identity
            GameObject temp = Instantiate(bullet, transform.position + transform.right * posBullet.x + transform.up * posBullet.y, Quaternion.identity); //簡寫
            // 暫存物件.取得元件<2D鋼體>().添加推力(角色的前方 * 子彈速度)
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed);
            // 刪除(物件 , 延遲秒數) 
            Destroy(temp, 1f);

            // 讓子彈的角度根玩家目前的角度相同 - 子彈角度問題
            //temp.transform.eulerAngles = transform.eulerAngles;
            //ParticleSystem.MainModule main = temp.GetComponent<ParticleSystem>().main;
            //main.flipRotation = transform.eulerAngles.y == 0 ? 0 : 1;
            ParticleSystemRenderer render = temp.GetComponent<ParticleSystemRenderer>();
            // 渲染的翻面 = 角色的角度 - ? : 三元運算子
            render.flip = new Vector3(transform.eulerAngles.y == 0 ? 0 : 1, 0, 0);
            // 計時器 = 數學.夾住(計時器,最小,最大); 
            timer = Mathf.Clamp(timer, 0, 5);
            //集氣:調整子彈尺寸
            // temp.transform.lossyScale = Vector3.one; //為唯獨 read only - 不能指定值 - 此行為錯誤示範會出現紅色錯誤標示
            temp.transform.localScale = Vector3.one + Vector3.one * timer;

            //計時器歸零
            timer = 0;
        }
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
