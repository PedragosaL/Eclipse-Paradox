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

    bool _canDie = true;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _graphicsRotation = transform.GetComponentInChildren<GraphicsRotation>();
        _animator = GetComponent<Animator>();
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

        enableCharacter(false);
        _animator.SetTrigger("Die");
        _canDie = false;
    }
}
