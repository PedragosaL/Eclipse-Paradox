using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public static DontDestroyOnLoadScene _instance;

    public GameObject[] _dontDestroyGameObjects;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }


    private void Start()
    {
        foreach (GameObject go in _dontDestroyGameObjects)
            DontDestroyOnLoad(go);
    }
}
