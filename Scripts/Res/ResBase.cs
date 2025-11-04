using Godot;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts.Res;

public abstract class ResBase
{
    public ResBase()
    {
        this.Load();
    }

    protected AppDataCore AppDataCore => Locator.Current.GetService<AppDataCore>();

    protected int Zoom => this.AppDataCore.ResourceZoom;

    public abstract void Load();

    protected string GetResUrl(string res)
    {
        return $"res://Resources{(this.AppDataCore.IsHD ? "HD" : string.Empty)}/{res}";
    }

    protected T LoadRes<T>(string res) where T : class
    {
        return GD.Load<T>(this.GetResUrl(res));
    }

}
