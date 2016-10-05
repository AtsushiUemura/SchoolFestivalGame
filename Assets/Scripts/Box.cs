using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            transform.localPosition += new Vector3(-1, 0, 0) * 0.1f;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
