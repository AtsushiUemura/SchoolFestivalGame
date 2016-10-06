using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Arrow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 30), 3).SetLoops(10, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
