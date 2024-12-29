using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour
{
    public Sprite _openedDoorTop;
    public Sprite _openedDoorBottom;

    public Sprite _closedDoorTop;
    public Sprite _closedDoorBottom;

    public GameObject _doorTop;
    public GameObject _doorBottom;

    SpriteRenderer _doorTopRendere;
    SpriteRenderer _doorBottomRendere;

    GameObject _keyHolder;
    bool _doorOpened = false;
    public UnityEvent<Transform> _characterReachedTheDoor;

    int _nbReachTheDoor = 0;

    public static DoorOpener _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_doorTop != null && _doorBottom != null)
        {
            _doorTopRendere = _doorTop.GetComponent<SpriteRenderer>();
            _doorBottomRendere = _doorBottom.GetComponent<SpriteRenderer>();
        } 
    }

    void openDoor()
    {
        _doorTopRendere.sprite = _openedDoorTop;
        _doorBottomRendere.sprite = _openedDoorBottom;
        _doorOpened = true;

        _nbReachTheDoor++;
        _characterReachedTheDoor.Invoke(_keyHolder.transform);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_keyHolder == null || collision.GetType() == typeof(CircleCollider2D))
            return;

        if (_doorOpened)
        {
            _characterReachedTheDoor.Invoke(collision.transform);
            if (++_nbReachTheDoor >= 2 )
                LevelManager._instance.loadNextLevel();
            Debug.Log(_nbReachTheDoor);
            
        }

        else if (collision.gameObject == _keyHolder)
            openDoor();
    }

    public void setKeyHolder(GameObject keyHolder) {  _keyHolder = keyHolder; Debug.Log(_keyHolder); }

    public void resetDoor()
    {
        _doorTopRendere.sprite = _closedDoorTop;
        _doorBottomRendere.sprite = _closedDoorBottom;
        _doorOpened = false;
        _nbReachTheDoor = 0;
        _keyHolder = null;
    }
}
