using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CubeRotate : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 90f;
    [SerializeField]
    private float _rotationDuration = 5f;

    private bool _inProgress = false;

    CancellationTokenSource _cTS = new CancellationTokenSource();

    public void StartRotation()
    {
        if (!_inProgress)
        {
            _cTS = new CancellationTokenSource();
            RotationCube();
        }       
    }

    public void StopRotation()
    {
        _cTS.Cancel();
    }

    private async void RotationCube()
    {
        _inProgress = true;

        for (float elapsedTime = 0; elapsedTime < _rotationDuration; elapsedTime += Time.deltaTime)
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
            await UniTask.NextFrame(_cTS.Token).SuppressCancellationThrow();
        }

        _inProgress = false;
    }
}
