using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.localPosition += new Vector3(speed, 0, 0);
    }
    private void OnBecameInvisible()
    {
        transform.localPosition = pos;
    }
}
