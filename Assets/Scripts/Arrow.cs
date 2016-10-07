using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    void Update()
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x, -2.7f, 4.9f);
    }
}
