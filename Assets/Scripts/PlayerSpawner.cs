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
    public bool _flipX = false;

    private void Start()
    {
        switch (_object)
        {
            case Object.Lumiere:
                {
                    GameObject character = GameObject.FindWithTag("Lumiere");
                    character.SetActive(true);
                    character.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.7f, 0);

                    var pb = character.GetComponent<PlayerBehaviour>();
                    pb.onLoad(true);
                    pb.enableCharacter(true);

                    if (_flipX)
                        character.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;

                    GameManager._instance.setCanSwitch(true);
                    break;
                }
            case Object.Ombre:
                {
                    GameObject character = GameObject.FindWithTag("Ombre");
                    character.SetActive(true);
                    character.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.7f, 0);

                    var pb = character.GetComponent<PlayerBehaviour>();
                    pb.onLoad(true);
                    pb.enableCharacter(false);

                    if (_flipX)
                        character.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;

                    GameManager._instance.setCanSwitch(true);
                    break;
                }
            case Object.Door:
                DoorOpener._instance.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.8f, 0);
                DoorOpener._instance.resetDoor();
                break;
            case Object.Key:
                {
                    GameObject key = GameObject.FindWithTag("DoorKey");
                    key.transform.position = new Vector3(transform.position.x+1, transform.position.y - 1.8f, 0);
                    key.GetComponent<SpriteRenderer>().enabled = true;
                    key.GetComponent<KeyCollecter>().resetKey();
                }
                break;
            default:
                break;
        }

        

    }
}
