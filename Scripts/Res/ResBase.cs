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

    public static string GetResUrl(string res)
    {
        var adc = Locator.Current.GetService<AppDataCore>();
        return $"res://Resources{(adc.IsHD ? "HD" : string.Empty)}/{res}";
    }

    public static T LoadRes<T>(string res) where T : class
    {
        return GD.Load<T>(GetResUrl(res));
    }

}
