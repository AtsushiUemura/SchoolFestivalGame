using UnityEngine;
using System.Collections;

public class InGameManager : MonoBehaviour
{

    private static bool isFinished;
    public static bool IsFinished
    {
        get
        {
            return isFinished;
        }
        set
        {
            isFinished = IsFinished;
        }
    }
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float enemyDestination;
    [SerializeField]
    private float playerDestination;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private MeshRenderer[] surface;
    [SerializeField]
    private SpriteRenderer arrow;
    private static int currentScore;
    private int time;

    #region
    IEnumerator Start()
    {
        Init();
        Coroutine coroutine = StartCoroutine(MoveEnemy());
        yield return coroutine;
        coroutine = StartCoroutine(MovePlayer());
        yield return coroutine;
        arrow.enabled = true;
        coroutine = StartCoroutine(EnableSurfaceMesh(surface[0]));
        yield return coroutine;
        coroutine = StartCoroutine(EnableSurfaceMesh(surface[1]));
        yield return coroutine;
        coroutine = StartCoroutine(EnableSurfaceMesh(surface[2]));
        yield return coroutine;
        coroutine = StartCoroutine(GameLoop());
        yield return coroutine;
        GameManager.I.HighScore = currentScore;
    }
    #endregion

    private void Init()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
    public static void AddScore(int score)
    {
        currentScore += score;
    }
    private IEnumerator MoveEnemy()
    {
        bool flag = false;
        while (!flag)
        {
            if (enemyDestination < enemy.transform.localPosition.x)
            {
                flag = true;
            }
            enemy.transform.localPosition += new Vector3(0.05f, 0, 0);
            yield return null;
        }
    }
    private IEnumerator MovePlayer()
    {
        bool flag = false;
        while (!flag)
        {
            if (playerDestination < player.transform.localPosition.x)
            {
                flag = true;
            }
            player.transform.localPosition += new Vector3(0.08f, 0, 0);
            yield return null;
        }
    }
    private IEnumerator EnableSurfaceMesh(MeshRenderer meshRenderer)
    {
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator GameLoop()
    {
        while (!IsFinished)
        {
            if (player.transform.localPosition.x < -4)
            {
                Debug.Log("finish");
                isFinished = true;
                player.GetComponent<Animator>().SetTrigger("Down");
            }
            yield return null;
        }
    }
}
