using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            isFinished = value;
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
    [SerializeField]
    private int time;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private GameObject result;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip joy;
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
        //StartCoroutine(Timer());
        StartCoroutine(ItemCreate());

        coroutine = StartCoroutine(GameLoop());
        yield return coroutine;

        //     GameManager.I.HighScore = currentScore;
        resultText.text = currentScore.ToString();
        //audioSource.PlayOneShot(joy);
        coroutine = StartCoroutine(ScaleChange(result, new Vector3(1,1,1), 0.5f));
        yield return coroutine;
        coroutine = StartCoroutine(TouchWait());
        yield return coroutine;
        yield return new WaitForSeconds(0.3f);

        yield return coroutine;
        SceneManager.LoadSceneAsync(sceneName);
    }
    #endregion

    private void OnEnable()
    {
        Init();
        StopAllCoroutines();
    }
    private void Init()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        time = 100;
        currentScore = 0;
        IsFinished = false;
    }
    public static void AddScore(int score)
    {
        currentScore += score;
    }
    /*
    private IEnumerator Timer()
    {
        while (0 < time)
        {
            time--;
            yield return new WaitForSeconds(1);
        }
        IsFinished = true;
    }
    */
    private IEnumerator ItemCreate()
    {
        while (!IsFinished)
        {
            Instantiate(item, new Vector3(7, Random.Range(0, 3), 6), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
    private IEnumerator TouchWait()
    {
        bool flag = false;
        while (!flag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                flag = true;
            }

            yield return null;
        }
    }
    private IEnumerator ScaleChange(GameObject item, Vector3 destination, float speed)
    {
        bool flag = false;
        while (!flag)
        {
            if (Vector3.Distance(item.transform.localScale, destination) < 0.01f)
            {
                flag = true;
            }
            float curvePos = animationCurve.Evaluate(speed);
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, destination, curvePos);
            yield return null;
        }
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
            scoreText.text = currentScore.ToString();
            timeText.text = time.ToString();
            if (player.transform.localPosition.x < -4)
            {
                Debug.Log("finish");
                isFinished = true;
            }
            yield return null;
        }
    }
}
