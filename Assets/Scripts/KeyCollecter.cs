using UnityEngine;
using UnityEngine.Events;

public class KeyCollecter : MonoBehaviour
{
    Transform _character = null;
    Rigidbody2D _characterRigidbody = null;

    public UnityEvent<GameObject> _keyHolder;

    bool _canBePicked = true;
    bool _isDropped = false;


    static bool _ombreHasKey = false;
    static bool _lumiereHasKey = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_canBePicked)
            return;

        if(collision.tag == "Ombre" && !_ombreHasKey)
        {
            _character = collision.transform;
            _characterRigidbody = collision.GetComponent<Rigidbody2D>();
            _keyHolder.Invoke(_character.gameObject);
            _canBePicked = false;
            _isDropped = false;
            _ombreHasKey = true;
        }

        else if(collision.tag == "Lumiere" && !_lumiereHasKey)
        {
            _character = collision.transform;
            _characterRigidbody = collision.GetComponent<Rigidbody2D>();
            _keyHolder.Invoke(_character.gameObject);
            _canBePicked = false;
            _isDropped = false;
            _lumiereHasKey = true;
        }
    }

    private void Update()
    {
        if(_character == null) return;

        if (_isDropped)
        {
            float distance = Vector3.Distance(transform.position, _character.transform.position);
            if(distance >= 1)
            {
                _canBePicked = true;
                _character = null;
            }

            return;
        }


        Vector3 newPos = transform.position;

        if (_characterRigidbody.linearVelocity.x > 0)
            newPos.x = _character.transform.position.x - 1;

        else if (_characterRigidbody.linearVelocity.x < 0)
            newPos.x = _character.transform.position.x + 1;

        newPos.y = _character.transform.position.y;

        transform.position = newPos;

        if (Input.GetButtonDown("DropKey"))
            dropKey();
    }

   

    void dropKey()
    {
        if (GameManager._instance.getCurrentCharacter() != _character)
            return;
    

        transform.position = new Vector2(_character.position.x, transform.position.y);
        _keyHolder.Invoke(null); 
        Debug.Log("Dropped");
        _isDropped = true;


        if (_character.tag == "Ombre")
            _ombreHasKey = false;
        else if (_character.tag == "Lumiere")
            _lumiereHasKey = false;
    }

    public void resetKey()
    {
        _character = null;
        _characterRigidbody = null;
        _canBePicked = true;
        _isDropped = false;

        _ombreHasKey = false;
        _lumiereHasKey = false;
    }

    
}
