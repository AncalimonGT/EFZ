using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;

namespace EFZ.Models.Characters;

public class AKANE : CharacterBase
{
    public AKANE(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/AKANE/AKANE.png");
    }

    public override string DisplayName => "里村茜";

    public override int Row => 0;

    public override int Column => 2;
}
