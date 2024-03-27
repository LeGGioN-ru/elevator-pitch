using System.Collections;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private GameSettings _gameSettings;
    private float _additionalSpeed;

    public float AdditionalSpeed => Mathf.Clamp(_additionalSpeed, 1, float.MaxValue);

    public void Init(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(AddSpeed());
    }

    private IEnumerator AddSpeed()
    {
        _additionalSpeed += _gameSettings.AddClickSpeed;
        yield return new WaitForSeconds(_gameSettings.DurationAddSpeed);
        _additionalSpeed -= _gameSettings.AddClickSpeed;
    }
}
