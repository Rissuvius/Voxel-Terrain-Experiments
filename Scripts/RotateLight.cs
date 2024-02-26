using Godot;
using System;

public partial class RotateLight : DirectionalLight3D
{
    public override void _Process(double delta)
    {
        RotateX((float)(delta * 0.5f));
    }
}
