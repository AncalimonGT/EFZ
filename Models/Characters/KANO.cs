using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Models.Characters;

public class KANO : CharacterBase
{
    public override string DisplayName => "雾岛佳乃";
    public override int Row => 4;

    public override int Column => 1;


    public KANO(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 17, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/KANO/KANO.png");
    }

}
