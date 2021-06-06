using UnityEngine;

public class learnLerp : MonoBehaviour
{
    public float a = 0;
    public float b = 10;
    public float posCam = 0;
    public float posPla = 100;
    public Vector3 vCam = new Vector3(0, 0, 0);
    public Vector3 vPla = new Vector3(100, 100, 100);

    private void Start()
    {
        // 認識插值 Lerp
        // 實現攝影機追蹤延遲的效果 數值會從(初始值)->(中間值)->(最終結果)
        float r = Mathf.Lerp(a, b, 0.5f);
        print("a與b中間值:" + r);
    }
    private void Update()
    {
        posCam = Mathf.Lerp(posCam, posPla, 0.5f);
        vCam = Vector3.Lerp(vCam, vPla, 0.5f);    
    }
}
