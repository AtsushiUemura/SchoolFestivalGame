using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}
