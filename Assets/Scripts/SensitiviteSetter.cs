using UnityEngine;
using Unity.Cinemachine;


public class SensitiviteSetter : MonoBehaviour
{
    public CinemachineInputAxisController inputAxis;
    [SerializeField] private PlayerData PlayerSense;
    
    private float newSens = 0;

    private void Update()
    {
        if (Mathf.Approximately(PlayerSense.sensitivity, newSens))
            return;

        foreach (var controller in inputAxis.Controllers)
        {
            Debug.Log($"Updating axis: {controller.Name}");

            // New Input System
            controller.Input.Gain =
                controller.Name.Contains("Y") ? -PlayerSense.sensitivity : PlayerSense.sensitivity;
        }
    }
}
