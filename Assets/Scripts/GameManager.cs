using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform _lumiere;
    PlayerBehaviour _lumiereBehaviour;

    public Transform _ombre;
    PlayerBehaviour _ombreBehaviour;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There is already an instance of GameManager");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        _lumiereBehaviour = _lumiere.GetComponent<PlayerBehaviour>();
        _lumiereBehaviour.enableCharacter(true);
        _ombreBehaviour = _ombre.GetComponent<PlayerBehaviour>();
        _ombreBehaviour.enableCharacter(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            switchCharacters();

        if (!_lumiere.gameObject.activeSelf || !_ombre.gameObject.activeSelf)
            return;

        float distanceBetweenCharac = Vector2.Distance(_lumiere.position, _ombre.position);
        if(distanceBetweenCharac < 6)
        {
            _lumiereBehaviour.die();
            _ombreBehaviour.die();
        }

    }

    void switchCharacters()
    {
        if (_lumiereBehaviour._isCurrentPlayer)
        {
            _lumiereBehaviour.enableCharacter(false);
            _ombreBehaviour.enableCharacter(true);
        }
        else
        {
            _ombreBehaviour.enableCharacter(false);
            _lumiereBehaviour.enableCharacter(true);
        }
    }

    public void characterCrossTheDoor(Transform character)
    {

        if (character == _lumiere || character == _ombre)
        {
            switchCharacters();
            character.gameObject.SetActive(false);
        }
    }
}
