using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Harvester))]
public class CharacterController : MonoBehaviour
{
    private Movement _movement;
    private Harvester _harvester;
    private IInputSystem _inputSystem;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _harvester = GetComponent<Harvester>();
        _inputSystem = new JoystickInput(FindObjectOfType<Joystick>());
    }

    private void Update()
    {
        //Input.GetMouseButtonDown(1)
        //_inputSystem.IsActionButtonUsed()
        if (Input.GetMouseButtonDown(1) && !_harvester.InProcess)
            _harvester.HarvestWheat();
    }

    private void FixedUpdate()
    {
        if (!_harvester.InProcess)
            TryMove();
    }

    private void TryMove()
    {
        var direction = _inputSystem.GetMoveDirection();
        if (direction.magnitude < 1e-4)
            return;

        _movement.Move(direction * Time.fixedDeltaTime);
    }
}
