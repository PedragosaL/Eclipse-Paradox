using UnityEngine;

public class TextManager : MonoBehaviour
{

    public GameObject _image;
    public GameObject _text;
    public GameObject _button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (!LevelManager._instance._canShowText)
        {
            _image.SetActive(false);
            _text.SetActive(false);
            _button.SetActive(false);
            return;
        }
        
        LevelManager._instance._canShowText = false;
        Cursor.visible = true;
        GameManager._instance._timeFroze = true;
    }

    public void cutText()
    {
        _image.SetActive(false);
        _text.SetActive(false);
        _button.SetActive(false);
        GameManager._instance._timeFroze = false;
    }

    public void setCursorVisibilty(bool isVisible)
    {
        Cursor.visible = isVisible;
    }
}
