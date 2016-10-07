using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rig;
    [SerializeField]
    private float jumpPower;
    private bool isJumped;
    private bool isDead;
    [SerializeField]
    private float speedUpRate;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jump;

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
            if (!isJumped && !InGameManager.IsFinished)
            {
                audioSource.PlayOneShot(jump);
                isJumped = true;
                rig.AddForce(Vector3.up * jumpPower);
                animator.SetTrigger("Jump");
            }
        }
    }
    private void SpeedUp()
    {
        if (transform.localPosition.x < 1)
        {
            transform.localPosition += new Vector3(speedUpRate, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            isJumped = false;
        }
        if (other.gameObject.CompareTag("Box"))
        {
            isJumped = false;
            rig.AddForce(new Vector3(-1, 0, 0) * 30);
        }
        if (other.gameObject.CompareTag("Item"))
        {
            if (-1.5f < transform.localPosition.x)
            {
                InGameManager.AddScore(2);
            }
            else
            {
                InGameManager.AddScore(1);
            }

        }
    }

}
