using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    PlayerMovement _playerMovement;
    RepelCharacter _repelCharacter;


    public bool _isCurrentPlayer;
    public GameObject _currentPlayerMark;

    public UnityEvent<GameObject> _playerDied;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _repelCharacter = GetComponent<RepelCharacter>();
    }

    public void enableCharacter(bool enable) { 
        _playerMovement.enabled = enable;
        _repelCharacter.enabled = enable;
        _isCurrentPlayer = enable;
        _currentPlayerMark.SetActive(enable);
    }

    public void die() {
        _playerDied.Invoke(this.gameObject);
    }
}
