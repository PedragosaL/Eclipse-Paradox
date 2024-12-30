using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    bool _canLoad = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LevelManager._instance == null)
            return;


        _canLoad = true;
        GameObject.FindWithTag("Lumiere").SetActive(false);
        GameObject.FindWithTag("Ombre").SetActive(false);

        Cursor.visible = true;
    }

    public void startGame()
    {
        if(_canLoad) 
            LevelManager._instance.startGame();
    }

    public void quit()
    {
        Application.Quit();
    }

}
