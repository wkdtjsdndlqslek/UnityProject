using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private T instance;
    public static T Instance { get { return Instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
