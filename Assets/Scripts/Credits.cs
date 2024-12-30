using UnityEngine;

public class Credits : MonoBehaviour
{
    public void backToMenu()
    {
        LevelManager._instance.loadMainMenu();
    }
}
