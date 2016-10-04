using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text scoreText;
    public float time;
    public int score;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = time.ToString();
        scoreText.text = score.ToString();
    }
}
