using UnityEngine;

public class PlayerInputManger : MonoBehaviour
{
    public static PlayerInputManger Instance;
    public PlayerInputMap Inputs;
    
    public Vector2 MoveInput;
    public bool SprintInput;
    public bool JumpInput;
    
    private void Awake()
    {
        Inputs = new PlayerInputMap();
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
 
    
    void OnEnable()
    {
        Inputs.Enable();
    }

    void OnDisable()
    {
        Inputs.Disable();
    }
        
    void Update()
    {
        Inputs.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        Inputs.Player.Move.canceled += ctx => MoveInput = Vector2.zero; 

        Inputs.Player.Sprint.performed += ctx => SprintInput = true;
        Inputs.Player.Sprint.canceled += ctx => SprintInput = false;

        Inputs.Player.Jump.performed += ctx => JumpInput = true;
        Inputs.Player.Jump.canceled += ctx => JumpInput = false;
    }
    
}
