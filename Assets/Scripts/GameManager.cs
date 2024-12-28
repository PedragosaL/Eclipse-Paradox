using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _lumiere;
    PlayerBehaviour _lumiereBehaviour;

    public GameObject _ombre;
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
}
