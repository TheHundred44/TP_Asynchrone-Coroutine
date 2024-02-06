using System.Collections;
using UnityEngine;

public class CubeTurn : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 90f;
    [SerializeField]
    private float _rotationDuration = 5f;

    private bool _inProgress = false;

    private Coroutine _rotateCube;

    public void StartRotation()
    {
        if (!_inProgress)
        {
            _rotateCube = StartCoroutine(RotateCube(_rotationSpeed, _rotationDuration));
        }
    }

    public void StopRotation()
    {
        StopCoroutine(_rotateCube);
        _inProgress = false;
    }

    IEnumerator RotateCube(float _speed, float _duration)
    {
        _inProgress = true;

        for (float elapsedTime = 0; elapsedTime < _duration; elapsedTime += Time.deltaTime)
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
            yield return null;
        }

        _inProgress = false;
    }
}
