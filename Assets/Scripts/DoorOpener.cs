using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour
{
    public Sprite _openedDoorTop;
    public Sprite _openedDoorBottom;

    public GameObject _doorTop;
    public GameObject _doorBottom;

    SpriteRenderer _doorTopRendere;
    SpriteRenderer _doorBottomRendere;

    GameObject _keyHolder;
    bool _doorOpened = false;
    public UnityEvent<Transform> _characterReachedTheDoor;

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

        _characterReachedTheDoor.Invoke(_keyHolder.transform);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_keyHolder == null)
            return;

        if (_doorOpened)
            _characterReachedTheDoor.Invoke(collision.transform);

        else if (collision.gameObject == _keyHolder)
            openDoor();
    }

    public void setKeyHolder(GameObject keyHolder) {  _keyHolder = keyHolder; Debug.Log(_keyHolder); }
}
