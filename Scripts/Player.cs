using Godot;
using System;

//TODO: MASSIVE CLEAN UP
//REFACTOR
//ENTITY SYSTEM
//COMMAND PATTERN
//STATE PATTERN
public partial class Player : CharacterBody3D
{
    float speed = 800f;
    float fastSpeed = 6000f;
    float mouseSens = .15f;
    float mouseSensitivity = .15f;
    float zoomMouseSensitivity = 0.035f;

    Node3D _gimble;
    Camera3D _camera;
    RayCast3D _ray;

    Vector3 _dir = new Vector3(0, 0, 0);
    Vector3 _move = new Vector3(0, 0, 0);

    public override void _Ready()
    {
        _gimble = GetNode<Node3D>("Gimble");
        _camera = GetNode<Camera3D>("Gimble/Camera3D");
        _ray = GetNode<RayCast3D>("Gimble/Camera3D/RayCast3D");

        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Process(double delta)
    {
        if (_ray.IsColliding())
        {
            // GD.Print(_ray.GetCollider());
        }

        //---Lock / Free mouse
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                Input.MouseMode = Input.MouseModeEnum.Visible;
            }
            else
            {
                Input.MouseMode = Input.MouseModeEnum.Captured;
            }
        }
        //--------------------

        GetMovementInputs();
        if (Input.IsActionPressed("zoom"))
        {
            _camera.Fov = 40;
            mouseSensitivity = zoomMouseSensitivity;
        }
        else
        {
            _camera.Fov = 90;
            mouseSensitivity = mouseSens;
        }
        // if (Input.IsActionJustPressed("mode_fullscreen"))
        // {
        //     OS.WindowFullscreen = !OS.WindowFullscreen;
        // }

        float y = _move.Y;
        _move.Y = 0;
        _dir = _dir.Normalized();
        _move.Y = y;

        if (Input.IsActionPressed("move_up")) _dir.Y += 1;
        if (Input.IsActionPressed("move_down")) _dir.Y += -1;
        if (Input.IsActionPressed("move_ctrl"))
        {
            _dir *= (float)(fastSpeed * delta);
        }
        else
        {
            _dir *= (float)(speed * delta);
        }

        // This might not be the fix
        Velocity = _dir;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
        {
            InputEventMouseMotion mouseEvent = @event as InputEventMouseMotion;
            _gimble.RotateX(Mathf.DegToRad(-mouseEvent.Relative.Y * mouseSensitivity));
            RotateY(Mathf.DegToRad(-mouseEvent.Relative.X * mouseSensitivity));

            Vector3 cameraRotation = _gimble.RotationDegrees;
            cameraRotation.X = Mathf.Clamp(cameraRotation.X, -70, 70);
            _gimble.RotationDegrees = cameraRotation;
        }
    }

    private void GetMovementInputs()
    {
        _move = new Vector3(0, 0, 0);
        _dir = new Vector3(0, 0, 0);
        Transform3D camXform = _camera.GlobalTransform;

        if (Input.IsActionPressed("move_forward")) _move.Z += 1;
        if (Input.IsActionPressed("move_backward")) _move.Z += -1;

        if (Input.IsActionPressed("move_left")) _move.X += -1;
        if (Input.IsActionPressed("move_right")) _move.X += 1;

        _dir += -camXform.Basis.Z * _move.Z;
        _dir += camXform.Basis.X * _move.X;
    }
}
