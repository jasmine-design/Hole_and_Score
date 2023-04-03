using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallController : MonoBehaviour
{
    // Start is called before the first frame update
    private string lastTouchBallObject = "None";

    public float minVelocity;
    public float maxSpeed;
    public Transform[] walls;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision){
        
        Debug.Log("Collided with " + collision.gameObject.name);
        // 檢查碰撞物體是否是球桿，是的話提醒犯規
        if(collision.gameObject.CompareTag("Club")){
            lastTouchBallObject = "Club";
            PoolGameController.GameInstance.Foul();
        }
        if (collision.gameObject.CompareTag("GravityWall")){
             // 設定反彈力量的最大值
            float maxBounce = 0.05f;
            float bounce = Mathf.Min(rb.velocity.magnitude * 0.1f, maxBounce);
            // 取得反射向量
            Vector3 reflected = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            // 計算反射後的速度
            rb.velocity = reflected.normalized * Mathf.Max(rb.velocity.magnitude - bounce, 0);
        }
    }
    private void FixedUpdate(){
        //Debug.Log("rb="+ rb.velocity.magnitude);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (rb.velocity.magnitude > minVelocity){
            // 射出一條向前的光線
            RaycastHit hit;
            if (Physics.Raycast(transform.position, rb.velocity.normalized, out hit)){
                Debug.Log("Hit"+hit.transform.name);
                Transform closestWall = null;
                float minDistance = Mathf.Infinity;

                // 找到最近的牆面
                foreach (Transform wall in walls){
                    float distance = Vector3.Distance(hit.point, wall.position);
                    if (distance < minDistance)
                    {
                        closestWall = wall;
                        minDistance = distance;
                    }
                }

                if (closestWall != null){
                    // 取得反射向量
                    Vector3 reflected = Vector3.Reflect(rb.velocity, closestWall.up);
                    // 計算反射後的速度
                    rb.velocity = reflected.normalized * rb.velocity.magnitude;
                }
            }
        }
    }

}
