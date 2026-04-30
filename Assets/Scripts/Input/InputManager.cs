using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public MainInputAsset inputs;

    private void Awake()
    {
        if (instance == null) instance = this;
        if (inputs == null) inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
}
