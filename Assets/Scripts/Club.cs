using UnityEngine;

public class Club : MonoBehaviour
{
    public int playerIndex; // 所属玩家编号
    public float hitPower = 3f; // 打击球的力量
    

    private Vector3 lastVelocity; // 上一帧的速度
    private Vector3 lastPosition;

    private void OnCollisionEnter(Collision collision)
    {
        // 碰撞到母球时传递速度和方向
        if (collision.gameObject.CompareTag("CueBall"))
        {
            // 获取母球的刚体组件
            Rigidbody cueBallRb = collision.gameObject.GetComponent<Rigidbody>();
            if (cueBallRb != null)
            {
                // 计算擊球力量和方向
                Vector3 clubPosition = transform.position;
                Quaternion clubRotation = transform.rotation;
                Vector3 clubForward = clubRotation * Vector3.forward;
                Vector3 hitDirection = clubForward.normalized;
                float hitPowerMultiplier = .5f; // 可以根据需要调整

                // 将擊球力量和方向应用于母球
                cueBallRb.AddForce(hitDirection * hitPower * hitPowerMultiplier, ForceMode.Impulse); 
                Debug.Log("Addforce to cueball");   
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
        Debug.Log("Club V:" + currentVelocity);

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
