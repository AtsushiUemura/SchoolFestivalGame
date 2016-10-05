using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rig;
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private Animator animator;

    void Start()
    {
       
    }
    void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (jumpCount == 0)
            {
                Debug.Log("0");
                jumpCount++;
                animator.SetTrigger("Jump");
                rig.AddForce(Vector3.up * 600);
            }
            else if (jumpCount == 1)
            {
                Debug.Log("1");
                jumpCount++;
                animator.SetTrigger("Jump");
                rig.AddForce(Vector3.up * 600);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Road") || other.gameObject.CompareTag("Box"))
        {
            jumpCount = 0;
        }
    }
}
