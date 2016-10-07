using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{

    public float speed;
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            transform.localPosition += new Vector3(-1, 0, 0) * speed;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
