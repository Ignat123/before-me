using UnityEngine;
using System.Collections;

public class SimpleSingletonScript : MonoBehaviour {

    public static SimpleSingletonScript control;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
