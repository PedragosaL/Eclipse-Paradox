using UnityEngine;

public class Pikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ombre" || collision.tag == "Lumiere")
        {
            if(collision.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour playerBehaviour))
                playerBehaviour.die();
        }
            
    }
}
