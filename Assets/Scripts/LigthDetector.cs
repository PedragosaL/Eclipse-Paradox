using UnityEngine;
using UnityEngine.Events;


public class LigthDetector : MonoBehaviour
{
    public enum LightType
    {
        Light,
        Shadow
    };

    public LightType _lightType;

    PlayerBehaviour _ombreBehaviour;
    PlayerBehaviour _lumiereBehaviour;

    private void Start()
    {
        _ombreBehaviour = GameObject.FindWithTag("Ombre").GetComponent<PlayerBehaviour>();
        _lumiereBehaviour = GameObject.FindWithTag("Lumiere").GetComponent<PlayerBehaviour>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (_lightType)
        {
            case LightType.Light:
                if (collision.tag == "Ombre")
                    _ombreBehaviour.die();
                break;

            case LightType.Shadow:
                if (collision.tag == "Lumiere")
                    _lumiereBehaviour.die();
                break;
            default:
                break;
        }
    }
}
