using UnityEngine;

public class CameraPositionFar : MonoBehaviour
{
    [SerializeField] float _ChangeViewPositionSpeed;
    [SerializeField] float _ChangeViewPositionTime;
    [SerializeField] float _ChangeViewRotationSpeed;
    [SerializeField] Camera _camera;
    [SerializeField] Transform _cameraTransform;

    bool _viewPositionIsChanged = false;
    bool _viewRotationIsChanged = false;


    private void OnEnable()
    {
        RocketTrigger.PlayerHasComeToTheRocket += ChangeView;
    }

    void Update()
    {
        if(_viewRotationIsChanged)
        {
            
            if(_cameraTransform.localEulerAngles.x - Time.deltaTime * _ChangeViewRotationSpeed <= 0)
            {
                _cameraTransform.localEulerAngles = Vector3.zero;
                _viewRotationIsChanged = false;
            }
            else
            {
                _cameraTransform.localEulerAngles -= new Vector3(1 * Time.deltaTime * _ChangeViewRotationSpeed, 0, 0);
            }
        }

        if(_viewPositionIsChanged)
        {

            if(_ChangeViewPositionTime - Time.deltaTime <= 0)
            {
                _viewPositionIsChanged = false;
            }
            else
            {
                _cameraTransform.localPosition += new Vector3(0, 0.3f, -1) * Time.deltaTime * _ChangeViewPositionSpeed;
                _ChangeViewPositionTime -= Time.deltaTime;
            }
            
        }
    }
    private void ChangeView()
    {
        _viewPositionIsChanged = true;
        _viewRotationIsChanged = true;
        _camera.farClipPlane = 100000;
    }

    private void OnDisable()
    {
        RocketTrigger.PlayerHasComeToTheRocket -= ChangeView;
    }




}
