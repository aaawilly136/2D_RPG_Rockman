using UnityEngine;

public class Player : MonoBehaviour
{
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
    
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
