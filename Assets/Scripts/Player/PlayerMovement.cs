using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// 玩家移动速度
    /// </summary>
    public float Speed = 6f;
    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //移动
        Move(h,v);

        //旋转
        Turning();

        //动画
        Animating(h, v);
    }

    void Move(float h,float v)
    {
        Vector3 movementV3 = new Vector3(h, 0, v);
        movementV3 = movementV3.normalized * Speed * Time.deltaTime;
        rb.MovePosition(transform.position + movementV3);
    }

    void Turning()
    {
        //创建相机（鼠标位置）
        Ray cameraray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int floorLayer = LayerMask.GetMask("Floor");

        RaycastHit floorHit;
        //射线检测
        bool IsTouchFloor = Physics.Raycast(cameraray,out floorHit,100,floorLayer);
        if (IsTouchFloor)
        {
            Vector3 v3 = floorHit.point - transform.position;
            v3.y = 0;

          Quaternion quaternion = Quaternion.LookRotation(v3);
            rb.MoveRotation(quaternion);
        }
    }

    void Animating(float h,float v)
    {
        if (h != 0 || v != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
