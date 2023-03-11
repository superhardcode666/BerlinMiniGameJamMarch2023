using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject freeLookCamera;
    private CinemachineFreeLook _freeLookComponent;

    private void Awake()
    {
        _freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            // use the following line for mouse control of zoom instead of mouse wheel
            // be sure to change Input Axis Name on the Y axis to "Mouse Y"

            //freeLookComponent.m_YAxis.m_MaxSpeed = 10;
            _freeLookComponent.m_XAxis.m_MaxSpeed = 500;
        if (Input.GetMouseButtonUp(1))
            // use the following line for mouse control of zoom instead of mouse wheel
            // be sure to change Input Axis Name on the Y axis from to "Mouse Y"

            //freeLookComponent.m_YAxis.m_MaxSpeed = 0;
            _freeLookComponent.m_XAxis.m_MaxSpeed = 0;

        // wheel zoom //
        // comment out the below if condition if you are using mouse control for zoom
        if (Input.mouseScrollDelta.y != 0) _freeLookComponent.m_YAxis.m_MaxSpeed = 10;
    }
}