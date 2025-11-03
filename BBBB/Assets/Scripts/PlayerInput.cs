using UnityEngine;


public class PlayerInput : MonoBehaviour
{
   #region InitInput

   private InputActions _inputActions;

   private void Awake()
   {
      _inputActions = new InputActions();
   }

   private void OnEnable()
   {
      _inputActions.Enable();
   }

   private void OnDisable()
   {
      _inputActions.Disable();
   }

   #endregion

   public Vector2 moveVector;
   public bool confirmButton;
   public bool menuDown;
   public bool menuUp;
   public bool menuLeft;
   public bool menuRight;
   public bool backPress;
   public bool menuPress;

   private void Update()
   {
      moveVector = _inputActions.Playerinputs.Move.ReadValue<Vector2>();
      confirmButton = _inputActions.Playerinputs.ConfirmButton.triggered;
      menuDown = _inputActions.Playerinputs.MenuDown.triggered;
      menuUp = _inputActions.Playerinputs.MenuUp.triggered;
      menuLeft = _inputActions.Playerinputs.MenuLeft.triggered;
      menuRight = _inputActions.Playerinputs.MenuLeft.triggered;
      backPress = _inputActions.Playerinputs.GoBack.triggered;
      menuPress = _inputActions.Playerinputs.MenuButton.triggered;
   }
}
