using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Models.Characters;

public class NANASE : CharacterBase
{
    public override string DisplayName => "七濑留美";
    public override int Row => 0;

    public override int Column => 1;

    public NANASE(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 5, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/NANASE/NANASE.png");
    }
}
