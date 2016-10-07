using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject item;

    IEnumerator Start()
    {
        Coroutine coroutine = StartCoroutine(Wait());
        yield return coroutine;
        coroutine = StartCoroutine(ItemCreate());
        yield return coroutine;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
    private IEnumerator ItemCreate()
    {
        while (!InGameManager.IsFinished)
        {
            GameObject clone = Instantiate(item, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(new Vector2(-100, Random.Range(0, 6) * 300));
            yield return new WaitForSeconds(Random.Range(8, 10) * 0.1f);
        }
    }

}
