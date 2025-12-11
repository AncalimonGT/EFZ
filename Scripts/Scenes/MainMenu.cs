using Godot;
using Splat;
using System.Collections.Generic;

namespace EFZ.Scripts;

public partial class MainMenu : NodeBase
{
    public List<TextureButton> Buttons { get; set; }

    public MainMenu()
    {
        this.Buttons = [];    
    }

    public override void _Ready()
    {
        var zoom = this.AppDataCore.ControlZoom;

        this.Log().Info("_Ready");

        var background = this.GetNode<TextureRect>("Background");
        background.Texture = DataRes.MainMenu.Background;

         

        for (int i = 0; i < DataRes.MainMenu.MenuItems.Count; i++)
        {
            var mi = DataRes.MainMenu.MenuItems[i];
            var mih = DataRes.MainMenu.MenuItemsHover[i];

            var size = mi.GetSize();
            var btn = new TextureButton
            {
                StretchMode = TextureButton.StretchModeEnum.Scale,
                TextureNormal = mi,
                TextureFocused = mih,
                Size = new Vector2(size.X * zoom, size.Y * zoom),
                ZIndex = i
            };

            this.Log().Info($"btn:{btn.Size}");

            btn.Position = new Vector2(this.AppDataCore.WindowsSize.X - btn.Size.X - 20, this.AppDataCore.WindowsSize.Y - (7 - i) * btn.Size.Y - 58);

            this.AddChild(btn);
            if (i == 0)
            {
                btn.GrabFocus();
            }

            this.Buttons.Add(btn);

            btn.FocusEntered += () =>
            {
                GD.Print($"{btn.Position.Y}");

                this.Globals.Play(DataRes.MainMenu.SelectedAudio);
            };

            btn.Pressed += () =>
            {
                this.Globals.Play(DataRes.MainMenu.ConfirmAudio);

                switch (btn.ZIndex)
                {
                    default:
                        break;

                    case 0:
                        this.GetTree().ChangeSceneToFile("res://Scenes/ChooseCharacter.tscn");
                        break;
                    case 6:
                        this.GetTree().Quit();
                        break;

                }

                if (btn.ZIndex == 6)
                {

                }
            };
        }






    }



    public override void _Process(double delta)
    {
        var up = Input.GetActionRawStrength("ui_up");

        if (up == 1)
        {
            GD.Print("yuop");

        }

    }
}
