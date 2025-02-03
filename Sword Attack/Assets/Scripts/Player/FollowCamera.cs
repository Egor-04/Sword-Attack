using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 1f; 
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _cameraTransform;

    private void Update()
    {
        try
        {
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, new Vector3(_target.position.x, _target.position.y, _cameraTransform.position.z), _followSpeed * Time.deltaTime);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Отсутствует ссылка на объект _target или _cameraTransfrom\nОшибка: {ex}");
        }
    }
}
