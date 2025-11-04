using Godot;
using Splat;
using System.Reactive.Disposables;

namespace EFZ.Scripts;

public abstract partial class NodeBase : Node, IEnableLogger
{
    protected readonly CompositeDisposable Disposables = [];

    protected AppDataCore AppDataCore => Locator.Current.GetService<AppDataCore>();

    protected DataRes DataRes => Locator.Current.GetService<DataRes>();
    protected Globals Globals => Locator.Current.GetService<Globals>();


    protected int Zoom => this.AppDataCore.ControlZoom;

    protected bool IsP1Selected { get; set; }

    protected bool IsP2Selected { get; set; }


    public override void _ExitTree()
    {
        Disposables?.Dispose();
 
        base._ExitTree();
    }

   

}
