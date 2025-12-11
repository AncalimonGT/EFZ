using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Models.Characters;

public class KAORI : CharacterBase
{
    public override string DisplayName => "美坂香里";
    public override int Row => 6;

    public override int Column => 2;

    public KAORI(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 13, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/KAORI/KAORI.png");
    }
}

