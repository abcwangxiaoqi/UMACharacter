using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
    static GameMain instacne=null;
    public static GameMain Instacne
    {
        get
        {
            if(instacne==null)
            {
                GameObject go = new GameObject("GameMain");
                instacne = go.AddComponent<GameMain>();
                go.transform.hideFlags = HideFlags.HideInHierarchy;
            }
            return instacne;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public CallBack startHandle;
    void Start()
    {
        if (startHandle != null)
        {
            startHandle();
        }
    }

    public CallBack destroyHandle;
    void OnDestroy()
    {
        if (destroyHandle!=null)
        {
            destroyHandle();
        }
    }
}
