using UnityEngine;
using System.Collections;

public class Witch : MonoBehaviour
{

    [SerializeField]
    private GameObject item;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ItemCreate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ItemCreate()
    {
        int count = 0;
        while (count < 5)
        {
            count++;
            GameObject clone = Instantiate(item, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(new Vector2(-1, 3) * 100);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
