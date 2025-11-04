using Autofac;
using Godot;
using ReactiveUI;
using Serilog;
using Serilog.Sinks.Godot;
using Splat;
using Splat.Autofac;
using Splat.Serilog;


namespace EFZ.Scripts;

public partial class Globals : Node, IEnableLogger
{
    public Globals()
    {
        //加载autofac
        var builder = new ContainerBuilder();
        var autofacResolver = builder.UseAutofacDependencyResolver();
        builder.RegisterInstance(autofacResolver);

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug() 
            .WriteTo.Godot()
            .CreateLogger();
        Locator.CurrentMutable.UseSerilogFullLogger();

        autofacResolver.InitializeReactiveUI();

        builder.RegisterType<AppDataCore>().SingleInstance();
        builder.RegisterType<DataRes>().SingleInstance();
        builder.RegisterInstance(this).As<Globals>().SingleInstance();

        var container = builder.Build();

        autofacResolver.SetLifetimeScope(container);
    }

    private AudioStreamPlayer AudioStreamPlayer { get; set; }



    public override void _Ready()
    {
        Locator.Current.GetService<AppDataCore>().WindowsSize = this.GetWindow().Size;

        this.AudioStreamPlayer = new AudioStreamPlayer() { VolumeDb = -8 };
        this.AddChild(this.AudioStreamPlayer);
    }


    public override void _Process(double delta)
    {
        var changeHD = Input.IsActionJustReleased("ChangeHD");

        if (changeHD)
        {
            var adc = Locator.Current.GetService<AppDataCore>();

            adc.IsHD = !adc.IsHD;

            var dr = Locator.Current.GetService<DataRes>();
            dr.ReLoad();
            this.GetTree().ReloadCurrentScene();
        }
    }


    public void Play(AudioStream audio)
    {
        this.AudioStreamPlayer.Stream = audio;
        this.AudioStreamPlayer.Play();

        this.Log().Debug("Play audio");
    }
}

