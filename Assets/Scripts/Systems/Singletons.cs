using UnityEngine;

public abstract class SingletonMB<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected bool IsBeingDestroyed { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            IsBeingDestroyed = true;
            return;
        }
        Instance = this as T;
        IsBeingDestroyed = false;
    }

    private void OnApplicationQuit()
    {
        if (Instance != null)
        {
            Instance = null;
            Destroy(gameObject);
            IsBeingDestroyed = true;
        }
    }
}

public abstract class PersistentSingletonMB<T> : SingletonMB<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}