using EFZ.Scripts.Characters;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts.Res.Characters;

public class SHIORIRes : CharactersResBase
{
    public override string DisplayName => "美坂栞";


    public SHIORIRes(Texture2D @object)
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion(3, 0)
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256, 122 * Zoom, 32 * Zoom)
        };
    }
}
