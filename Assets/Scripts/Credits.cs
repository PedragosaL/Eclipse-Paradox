using UnityEngine;

public class Credits : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }
    public void backToMenu()
    {
        LevelManager._instance.loadMainMenu();
    }
}
