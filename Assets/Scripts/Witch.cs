using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Witch : MonoBehaviour
{

    [SerializeField]
    private GameObject item;

    // Use this for initialization
    IEnumerator Start()
    {
        Coroutine coroutine = StartCoroutine(Move());
        yield return coroutine;
        coroutine = StartCoroutine(ItemCreate());
        yield return coroutine;
        coroutine = StartCoroutine(MoveBack());
        yield return coroutine;
        transform.localPosition = new Vector3(-15, 5, 6);
    }

    private IEnumerator Move()
    {
        transform.DOMove(new Vector3(2, 2, 6), 3);
        yield return new WaitForSeconds(3);
    }
    private IEnumerator MoveBack()
    {
        transform.DOMove(new Vector3(15, 5, 6), 3);
        yield return new WaitForSeconds(3);
    }
    private IEnumerator ItemCreate()
    {
        int count = 0;
        while (count < 5)
        {
            count++;
            GameObject clone = Instantiate(item, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(new Vector2(-1, 2) * 100);
            yield return new WaitForSeconds(Random.Range(5, 10) * 0.1f);
        }
        yield return new WaitForSeconds(1);
    }
}
