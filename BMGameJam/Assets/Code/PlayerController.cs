using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 25f;

    public float lookRateSpeed = 90f;

    private float _activeForwardSpeed;
    private readonly float _forwardAcceleration = 2.5f;
    private Vector3 _lookInput, _screenCenter, _mouseDistance;
    
    public static PlayerController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        _screenCenter.x = Screen.width * 0.5f;
        _screenCenter.y = Screen.height * 0.5f;
    }

    private void Update()
    {
        _lookInput.x = Input.mousePosition.x;
        _lookInput.y = Input.mousePosition.y;

        _mouseDistance.x = (_lookInput.x - _screenCenter.x) / _screenCenter.y;
        _mouseDistance.y = (_lookInput.y - _screenCenter.y) / _screenCenter.y;

        _mouseDistance = Vector2.ClampMagnitude(_mouseDistance, 1f);

        transform.Rotate(-_mouseDistance.y * lookRateSpeed * Time.deltaTime,
            _mouseDistance.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, 1 * forwardSpeed, _forwardAcceleration * Time.deltaTime);

        transform.position += transform.forward * (_activeForwardSpeed * Time.deltaTime);
    }
}