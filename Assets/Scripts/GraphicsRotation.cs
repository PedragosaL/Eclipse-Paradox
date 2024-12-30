using UnityEngine;

public class GraphicsRotation : MonoBehaviour
{
    SpriteRenderer _sp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sp = transform.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance._timeFroze)
            return;

        if (Input.GetAxisRaw("Horizontal") == -1)
            _sp.flipX = true;

        if (Input.GetAxisRaw("Horizontal") == 1)
            _sp.flipX = false;
    }

}
