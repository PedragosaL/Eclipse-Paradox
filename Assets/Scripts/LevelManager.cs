using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager _instance;
    public UnityEvent _loadScene;

    int _currentLevel = 1;

    private void Awake()
    {
        if(_instance != null)
        {
            Debug.Log("There is already an instance of Level Manager");
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            loadMainMenu();
    }

    string getLevel()
    {
        switch (_currentLevel)
        {
            case 0: return "Main menu";
            case 1: return "Level 1";
            case 2: return "Level 2";
            case 3: return "Level 3";
            case 4: return "Level 4";

        }
        return "Main menu";
    }


    public void loadNextLevel()
    {
        _currentLevel++;
        loadScene(getLevel());
    }

    public void startGame()
    {
        SceneManager.LoadScene(getLevel());
        _loadScene.Invoke();
    }

    public void reloadLevel()
    {
        loadScene(getLevel());
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Main menu");
        _loadScene.Invoke();
    }

    void loadScene(string sceneName)
    {
        StartCoroutine(waitForSeconds(1f, sceneName));
    }

    IEnumerator waitForSeconds(float seconds, string sceneName) {  
        yield return new WaitForSeconds(seconds);
        _loadScene.Invoke();
        SceneManager.LoadScene(sceneName);
    }
    
}
