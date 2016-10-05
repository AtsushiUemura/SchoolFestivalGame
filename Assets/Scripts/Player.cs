using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rig;
    [SerializeField]
    private float jumpPower;
    private int jumpCount;
    private bool isDead;
    [SerializeField]
    private float speedUpRate;
    [SerializeField]
    private float speedUpSpan;
    [SerializeField]
    private Animator animator;

    void Start()
    {

    }
    void Update()
    {
        Jump();
        SpeedUp();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*
            if (jumpCount == 1)
            {
                jumpCount++;
                rig.AddForce(Vector3.up * jumpPower * 0.5f, ForceMode.Force);
                animator.SetTrigger("Jump");

            }
            */
            if (jumpCount == 0)
            {
                jumpCount++;
                rig.AddForce(Vector3.up * jumpPower);
                animator.SetTrigger("Jump");
            }
        }
    }
    private void SpeedUp()
    {
        transform.localPosition += new Vector3(speedUpRate, 0, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            jumpCount = 0;
        }
        if (other.gameObject.CompareTag("Box"))
        {
            jumpCount = 0;
            rig.AddForce(new Vector3(1, 1, 0) * 10);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            rig.AddForce(Vector3.left * 300);
        }
    }

}
