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
        // coroutine = StartCoroutine(MoveBack());
        // yield return coroutine;

    }

    private IEnumerator Move()
    {
        transform.DOMove(new Vector3(2, 2, 6), 3);
        yield return new WaitForSeconds(6);
    }
    private IEnumerator MoveBack()
    {
        transform.DOMove(new Vector3(15, 5, 6), 3);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    private IEnumerator ItemCreate()
    {
        int count = 0;
        while (!InGameManager.IsFinished)
        {
            count++;
            Instantiate(item, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        yield return new WaitForSeconds(1);
    }
}
