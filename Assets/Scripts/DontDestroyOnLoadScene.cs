using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] _dontDestroyGameObjects;

    private void Start()
    {
        foreach (GameObject go in _dontDestroyGameObjects)
            DontDestroyOnLoad(go);
    }
}
