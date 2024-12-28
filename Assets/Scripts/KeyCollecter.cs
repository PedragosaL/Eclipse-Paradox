using UnityEngine;
using UnityEngine.Events;

public class KeyCollecter : MonoBehaviour
{
    Transform _character = null;
    Rigidbody2D _characterRigidbody = null;

    BoxCollider2D _collider;


    public UnityEvent<GameObject> _keyHolder;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ombre" || collision.tag == "Lumiere")
        {
            _character = collision.transform;
            _characterRigidbody = collision.GetComponent<Rigidbody2D>();
            _collider.enabled = false;
            _keyHolder.Invoke(_character.gameObject);
        }
    }

    private void Update()
    {
        if(_character == null) return;

        Vector3 newPos = transform.position;

        if (_characterRigidbody.linearVelocity.x > 0)
            newPos.x = _character.transform.position.x - 1;

        else if (_characterRigidbody.linearVelocity.x < 0)
            newPos.x = _character.transform.position.x + 1;

        newPos.y = _character.transform.position.y;

        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.F))
            dropKey();
    }


    void dropKey()
    {
        _collider.enabled = true;
        _character = null;
        _keyHolder.Invoke(null);
        Debug.Log("Dropped");
    }
}
