using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T i;
    public static T I
    {
        get
        {
            if (i == null)
            {
                i = (T)FindObjectOfType(typeof(T));

                if (i == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }

            return i;
        }
    }

}