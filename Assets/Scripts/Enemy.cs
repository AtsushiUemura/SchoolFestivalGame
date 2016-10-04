using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private bool isDead;
    [SerializeField]
    private Rigidbody rig;
    [SerializeField]
    private GameObject item;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(ItemCreate());
        StartCoroutine(Effect());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Effect()
    {
        while (!isDead)
        {
            
            yield return new WaitForSeconds(3);
        }
    }
    private IEnumerator Move()
    {
        while (!isDead)
        {
            rig.AddForce(new Vector2(0, 1) * 200);
            yield return new WaitForSeconds(1);
        }
    }
    private IEnumerator ItemCreate()
    {
        while (!isDead)
        {
            GameObject clone = Instantiate(item, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(new Vector2(-1, Random.Range(0, 6)) * 100);
            yield return new WaitForSeconds(Random.Range(5, 8) * 0.1f);
        }
    }

}
