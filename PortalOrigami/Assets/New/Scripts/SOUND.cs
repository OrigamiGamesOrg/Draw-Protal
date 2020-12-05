using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND : MonoBehaviour
{
    public static SOUND instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
