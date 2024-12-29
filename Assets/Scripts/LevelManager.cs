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
            case 0: return "First scene";
            case 1: return "test";
        }
        return "Main menu";
    }


    public void loadNextLevel()
    {
        _currentLevel++;
        loadScene(getLevel());
    }

    public void loadInitScene()
    {
        loadScene("First scene");
    }

    public void reloadLevel()
    {
        loadScene(getLevel());
    }

    public void loadMainMenu()
    {
        loadScene("Main menu");
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
