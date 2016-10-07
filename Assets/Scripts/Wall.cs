using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float speedRate;
    [SerializeField]
    private float posX;
    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private float speedUpSpan;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.localPosition.x < posX)
        {
            transform.localPosition = pos;
        }
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedRate;
        }
        transform.localPosition += new Vector3(-currentSpeed, 0, 0);
    }
}
