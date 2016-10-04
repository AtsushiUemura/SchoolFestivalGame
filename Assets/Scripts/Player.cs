using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            gameManager.time -= 5;
        }
        if (other.gameObject.CompareTag("Item"))
        {
            gameManager.score++;
        }
    }
}
