using EFZ.Scripts.Characters;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts.Res.Characters;

public class NAYUKIBRes : CharactersResBase
{
    public override string DisplayName => "水濑名雪";

    public NAYUKIBRes(Texture2D @object)
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = GetAvatarRegion(6, 0)
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256, 122 * Zoom, 32 * Zoom)
        };
    }
}