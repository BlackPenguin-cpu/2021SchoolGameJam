using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T t;
                t = FindObjectOfType(typeof(T)) as T;
                if (t == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    obj.AddComponent<T>();
                    instance = obj.GetComponent<T>();
                }

                else
                {
                    instance = t.GetComponent<T>();
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
