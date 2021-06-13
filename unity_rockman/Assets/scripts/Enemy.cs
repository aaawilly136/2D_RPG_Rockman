﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 200)]
    public float speed = 1f;
    [Header("攻擊力"), Range(0, 100)]
    public float attack = 10f;
    [Header("血量"), Range(0, 500)]
    public float hp = 200f;
    [Header("偵測範圍"), Range(0, 50)]
    public float radiusTrack = 5f;
    [Header("攻擊範圍"), Range(0, 50)]
    public float radiusAttack = 2;
    [Header("攻擊冷卻"), Range(0, 30)]
    public float cd = 1;
    [Header("偵測地板的位移與半徑")]
    public Vector3 groundoffest;
    public float groundRadius = 0.1f;

    private Transform player;
    private Rigidbody2D rig;
    private Animator ani;
    private float timer;
    private float speedOringinal;
    #endregion
    #region 事件
    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        //玩家 = 遊戲物件.尋找("物件名稱") - 搜尋場境內所有物件
        //transform.Find("子物件名稱") - 搜尋此物件的子物件
        player = GameObject.Find("玩家").transform;
        //讓敵人一碰到玩家就開始攻擊
        timer = cd;
        speedOringinal = speed;
    }
    private void Update()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, radiusTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);
        
        
        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * groundoffest.x + transform.up * groundoffest.y, groundRadius);
    }
    #endregion
    #region 方法
    private void Move()
    {
        //如果玩家 跟敵人的 距離 小於等於 追蹤範圍 就移動

        // 距離 = 三維向量.距離(a點,b點)
        float dis = Vector3.Distance(player.position, transform.position);

        if (dis <= radiusAttack)
        {
            Attack();
        }
        else if (dis <= radiusTrack)
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("走路開關", speed != 0);   //速度不等於零時 走路 否則 等待
            LookAtPlayer();
            CheckGround();
            
        }
        else
        {
            ani.SetBool("走路開關", false);
            timer = cd;
        }
    }
    private void Attack()
    {
        if (timer <= cd)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            ani.SetTrigger("滑步攻擊");
        }
        
    }
    /// <summary>
    /// 面相玩家
    /// </summary>
    private void LookAtPlayer()
    {
        // 如果敵人 x 大於玩家x就代表玩家在左邊 角度180
        if(transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // 否則敵人 x 小於玩家 x 就代表玩家在右邊 角度0
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void CheckGround() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundoffest.x + transform.up * groundoffest.y, groundRadius, 1 << 8);
        
        // 判斷式 程式只有一句(一個分號) 可以省略大括號
        if (hit && (hit.name == "地板" || hit.name =="跳台"))
        {          
           speed = speedOringinal;
        }
        else
        {
           speed = 0;
        }
    }
    #endregion

}
