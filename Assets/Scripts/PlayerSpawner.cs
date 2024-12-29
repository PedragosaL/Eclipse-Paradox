using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public enum Object
    {
        Lumiere,
        Ombre,
        Door,
        Key
    };

    public Object _object;

    private void Start()
    {
        switch (_object)
        {
            case Object.Lumiere:
                {
                    GameObject character = GameObject.FindWithTag("Lumiere");
                    character.SetActive(true);
                    character.transform.position = transform.position;

                    var pb = character.GetComponent<PlayerBehaviour>();
                    pb.onLoad(true);
                    pb.enableCharacter(true);

                    GameManager._instance.setCanSwitch(true);
                    break;
                }
            case Object.Ombre:
                {
                    GameObject character = GameObject.FindWithTag("Ombre");
                    character.SetActive(true);
                    character.transform.position = transform.position;

                    var pb = character.GetComponent<PlayerBehaviour>();
                    pb.onLoad(true);
                    pb.enableCharacter(false);

                    GameManager._instance.setCanSwitch(true);
                    break;
                }
            case Object.Door:
                DoorOpener._instance.transform.position = transform.position;
                DoorOpener._instance.resetDoor();
                break;
            case Object.Key:
                {
                    GameObject key = GameObject.FindWithTag("DoorKey");
                    key.transform.position = transform.position;
                    key.GetComponent<SpriteRenderer>().enabled = true;
                    key.GetComponent<KeyCollecter>().resetKey();
                }
                break;
            default:
                break;
        }

        

    }
}
