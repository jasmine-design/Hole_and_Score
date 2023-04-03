using UnityEngine;

public class Club : MonoBehaviour
{
    public int playerIndex; // 所属玩家编号
    public float hitPower = 10f; // 打击球的力量
    

    private Vector3 lastVelocity; // 上一帧的速度
    private Vector3 lastPosition;

    private void OnCollisionEnter(Collision collision)
    {
        // 碰撞到母球时传递速度和方向
        if (collision.gameObject.CompareTag("CueBall"))
        {
            Debug.Log("club hit the cueball.");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 计算球拍的速度和方向
                Vector3 clubVelocity = GetComponent<Rigidbody>().velocity;
                Vector3 clubDirection = clubVelocity.normalized;

                Debug.Log("clubVelocity = " + clubVelocity);
                Debug.Log("clubDirection = " + clubDirection);
                
                // 计算球拍击打球的力量
                float power = hitPower * clubVelocity.magnitude;
                
                // 传递球拍的速度和方向到母球
                rb.AddForce(clubDirection * power, ForceMode.Impulse);
                Debug.Log("add force to cueball.");
            }
        }
    }

    private void FixedUpdate()
    {
        // 记录上一帧的速度
        lastVelocity = GetComponent<Rigidbody>().velocity;
        lastPosition = transform.position;
    }
    

    private void LateUpdate()
    {
        Vector3 currentVelocity = (transform.position - lastPosition) / Time.deltaTime;
        Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);

        // 限制球拍速度
        float maxSpeed = 10f;
        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }

        // 将上一帧的速度应用到球拍上
        GetComponent<Rigidbody>().velocity = lastVelocity;
    }
}
