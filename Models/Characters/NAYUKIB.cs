using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Models.Characters;

public class NAYUKIB : CharacterBase
{
    public override string DisplayName => "水濑名雪";

    public override int Row => 6;

    public override int Column => 0;

    public NAYUKIB(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 8, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/NAYUKIB/NAYUKIB.png");
    }
}
