using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallController : MonoBehaviour
{
    public int lastPlayerIndex = -1;

    public GameObject cueBall;
    public GameObject club;
    private Vector3 direction;
    public float power;
    public float velocitystopThreshold;
    public float angularstopThreshold;
    public float maxSpeed;

    [SerializeField] private Rigidbody rb; // 加入 Rigidbody 變數
    private PoolGameController poolgameController;

    private bool ballStartMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // 取得 Rigidbody 的參考
        poolgameController = GameObject.Find("GameManager").GetComponent<PoolGameController>();
    }


    // 檢查母球是否被擊打
    void OnCollisionEnter(Collision collision){
    // 檢查碰撞物體是否是球拍
        if(collision.gameObject.CompareTag("Club")){
            // 碰撞物體是球拍，獲取該球拍所屬的玩家編號
            int playerIndex = collision.gameObject.GetComponentInParent<Club>().playerIndex;
            // 更新最後一次擊打母球的玩家編號
            lastPlayerIndex = playerIndex;
            // 計算擊打方向和力量 ---
            direction = club.transform.position - cueBall.transform.position;
            float hitPower = club.GetComponent<Rigidbody>().velocity.magnitude;
            Debug.Log("Hit power: " + hitPower);
            Debug.Log("Hit direction: " + direction);
            // 偵測開球 ---
            cueBall.GetComponent<Rigidbody>().velocity = direction.normalized * power;
            // 母球開始移動
            ballStartMoving = true;
            enabled = true;
        }

    }

    private void FixedUpdate()
    {
        Debug.Log("cueBall" + rb.velocity.magnitude + rb.angularVelocity.magnitude);
        
        if(ballStartMoving){
            if (rb.velocity.magnitude > maxSpeed){
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            if (rb.velocity.magnitude < velocitystopThreshold && rb.angularVelocity.magnitude < angularstopThreshold && !rb.IsSleeping())
            {
                Debug.Log("Stop the ball");
                // 如果球速度太慢、角速度太慢，並且球沒有進入睡眠狀態，就設定速度為 0
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                ballStartMoving = false;
                // 確定球已經靜止，就可以禁用 CueBallController 了
                enabled = false;
            }
        }
        
    }



}