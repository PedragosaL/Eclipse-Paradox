using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent (typeof(Light2D))]
public class DisableLightTrap : MonoBehaviour
{
    Light2D _light;
    bool _canDisable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    private void Update()
    {
  
        if (!_canDisable)
            return;


        _light.intensity -= 50 * Time.deltaTime;
        //StartCoroutine(decrementIntensity());

        if (_light.intensity <= 0)
        {
            _canDisable = false;
            gameObject.SetActive(false);
        }
    }

    public void disableLight()
    {
        _canDisable = true;
    }

}
