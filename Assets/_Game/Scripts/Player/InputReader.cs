using UnityEngine;
using UnityEngine.InputSystem;

namespace WaveSurvival.Player
{
    /*
 * Controls player movement.
 *
 * Responsibilities:
 * - Reads player input.
 * - Moves the player.
 */
    public class InputReader : MonoBehaviour
    {
        private PlayerInputActions inputActions;

        public Vector2 MoveInput { get; private set; }

        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Enable();

            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;
        }

        private void OnDisable()
        {
            inputActions.Player.Move.performed -= OnMove;
            inputActions.Player.Move.canceled -= OnMove;

            inputActions.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }
}