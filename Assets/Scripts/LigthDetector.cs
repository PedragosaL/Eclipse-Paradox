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
    public UnityEvent _killLumiere;
    public UnityEvent _killOmbre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (_lightType)
        {
            case LightType.Light:
                if (collision.tag == "Ombre")
                    _killOmbre.Invoke();
                break;

            case LightType.Shadow:
                if (collision.tag == "Lumiere")
                    _killLumiere.Invoke();
                break;
            default:
                break;
        }
    }
}
