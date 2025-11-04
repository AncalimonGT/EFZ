using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts;

public class AppDataCore
{
    public bool IsHD { get; set; } = false;


    public int ResourceZoom => this.IsHD ? 4 : 1;
    public int ControlZoom => this.IsHD ? 1 : 4;


    public Vector2I WindowsSize { get; set; }
}
