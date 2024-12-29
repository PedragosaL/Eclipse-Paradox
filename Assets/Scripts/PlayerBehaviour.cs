using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    PlayerMovement _playerMovement;
    GraphicsRotation _graphicsRotation;

    public bool _isCurrentPlayer;
    public GameObject _currentPlayerMark;

    public UnityEvent<GameObject> _playerDied;
    Animator _animator;
    Rigidbody2D _rb;

    bool _canDie = true;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _graphicsRotation = transform.GetComponentInChildren<GraphicsRotation>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        if (_playerDied == null)
            _playerDied = new UnityEvent<GameObject>();
        _playerDied.AddListener(obj => _playerMovement.setCanMove(false));
    }

    public void enableCharacter(bool enable) { 
        _playerMovement.enabled = enable;
        _graphicsRotation.enabled = enable;
        _isCurrentPlayer = enable;
        _currentPlayerMark.SetActive(enable);
    }

    public void die() {
        if (!_canDie)
            return;

        _playerDied.Invoke(this.gameObject);
        Debug.Log(this.name + " Died !");

        stopInertia();
        _rb.gravityScale = 0;
        enableCharacter(false);
        _animator.SetTrigger("Die");
        _canDie = false;
    }

    public void OnDeathAnimationEnd()
    {
        this.gameObject.SetActive(false);   
    }

    public void onLoad(bool afterLoad)
    {
        _canDie = afterLoad;
        _rb.gravityScale = (afterLoad) ? 1 : 0;
        enableCharacter(afterLoad);
        transform.GetComponentInChildren<SpriteRenderer>().enabled = afterLoad;
        GetComponent<PlayerMovement>().setCanMove(true);
    }

    public void stopInertia()
    {
        _rb.linearVelocity = Vector2.zero;
    }
}
