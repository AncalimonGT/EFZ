using Godot;
using Splat;
using System.Collections.Generic;

namespace EFZ.Scripts.Res;

public class MainMenuRes: ResBase
{

    public Texture2D Background { get; set; }
    public List<AtlasTexture> MenuItems { get; set; }
    public List<AtlasTexture> MenuItemsHover { get; set; }

    public AudioStream SelectedAudio { get; set; }
    public AudioStream ConfirmAudio { get; set; }

 
    public override void Load()
    {
        this.MenuItems = [];
        this.MenuItemsHover = [];
               

        this.Background = ResBase.LoadRes<Texture2D>("SYSTEM/TITLE.png");

        var title_ob = ResBase.LoadRes<Texture2D>("SYSTEM/TITLE_OB.png");

        var ract = 196 * this.Zoom / 14;

        for (int i = 0; i < 7; i++)
        {
            var at = new AtlasTexture()
            {
                Atlas = title_ob,
                Region = new Rect2(0, ract * i, 120 * this.Zoom, ract)
            };

            var ath = new AtlasTexture()
            {
                Atlas = title_ob,
                Region = new Rect2(0, ract * (7 + i), 120 * this.Zoom, ract),
            };

            this.MenuItems.Add(at);
            this.MenuItemsHover.Add(ath);
        }

        this.SelectedAudio = GD.Load<AudioStream>("res://Audio/08.wav");
        this.ConfirmAudio = GD.Load<AudioStream>("res://Audio/06.wav");
    }


}
