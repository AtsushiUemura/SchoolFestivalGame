using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Item : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Move()
    {
        transform.localPosition += new Vector3(speed, 0, 0);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GameManager.I.AddScore(1));
            Destroy(gameObject);
        }
    }
}
