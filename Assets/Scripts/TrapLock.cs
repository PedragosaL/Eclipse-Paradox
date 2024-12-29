using UnityEngine;
using UnityEngine.Events;

public class TrapLock : MonoBehaviour
{
    public GameObject _key;

    GameObject _keyHolder;
    public UnityEvent _trapUnlocked;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_key == null)
            return;

        KeyCollecter keyCollecter = _key.GetComponent<KeyCollecter>();
        if (keyCollecter._keyHolder == null)
            keyCollecter._keyHolder = new UnityEvent<GameObject>();
        keyCollecter._keyHolder.AddListener(setKeyHolder);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_keyHolder == null)
            return;

        else if (collision.gameObject == _keyHolder)
        {
            Debug.Log("Dévérouiller");
            _trapUnlocked.Invoke();
            _key.SetActive(false);
            this.gameObject.SetActive(false );
        }

    }

    public void setKeyHolder(GameObject keyHolder) { _keyHolder = keyHolder; Debug.Log(_keyHolder); }
}

