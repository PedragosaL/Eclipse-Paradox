using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public Transform _lumiere;
    PlayerBehaviour _lumiereBehaviour;

    public Transform _ombre;
    PlayerBehaviour _ombreBehaviour;

    bool _canSwicth = true;

    public bool _timeFroze = false;

    public void setTimeFroze(bool timeFroze) { _timeFroze = timeFroze; }

    public GameObject _pauseUI;

    void Awake()
    {
        if(_instance != null)
        {
            Debug.Log("There is already an instance of GameManager");
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
    }

    void Start()
    {
        _lumiereBehaviour = _lumiere.GetComponent<PlayerBehaviour>();
        _ombreBehaviour = _ombre.GetComponent<PlayerBehaviour>();

        _lumiere.gameObject.SetActive(true);
        _ombre.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeFroze)
            return;

        if (Input.GetButtonDown("Pause"))
        {
            _pauseUI.SetActive(true);
            _timeFroze = true;
        }

        if (Input.GetButtonDown("SwitchCharacter"))
            switchCharacters();

        if (!_lumiere.gameObject.activeSelf || !_ombre.gameObject.activeSelf)
            return;

        float distanceBetweenCharac = Vector2.Distance(_lumiere.position, _ombre.position);
        if(distanceBetweenCharac < 5)
        {
            _lumiereBehaviour.die();
            _ombreBehaviour.die();
        }

    }

    void switchCharacters()
    {
        if (!_canSwicth)
            return;

        if (_lumiereBehaviour._isCurrentPlayer)
        {
            _lumiereBehaviour.enableCharacter(false);
            _lumiereBehaviour.stopInertia();
            _ombreBehaviour.enableCharacter(true);
        }
        else
        {
            _ombreBehaviour.enableCharacter(false);
            _ombreBehaviour.stopInertia();
            _lumiereBehaviour.enableCharacter(true);
        }
    }

    public void characterCrossTheDoor(Transform character)
    {

        if (character == _lumiere || character == _ombre)
        {
            switchCharacters();
            character.gameObject.SetActive(false);
            _canSwicth = false;
        }
    }

    public void setCanSwitch(bool canSwitch) { _canSwicth = canSwitch; }
  
    public Transform getCurrentCharacter()
    {
        if (_lumiereBehaviour._isCurrentPlayer)
            return _lumiere;
        else if (_ombreBehaviour._isCurrentPlayer)
            return _ombre;

        return null;
    }
}
