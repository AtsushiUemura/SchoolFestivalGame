using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField]
    private bool tach;
    [SerializeField]


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tach = Input.GetMouseButtonDown(0);
  
    }
}
