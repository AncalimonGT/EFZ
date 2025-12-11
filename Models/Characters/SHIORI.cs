using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;

namespace EFZ.Models.Characters;

public class SHIORI : CharacterBase
{
    public override string DisplayName => "美坂栞";

    public override int Row => 3;

    public override int Column => 0;

    public SHIORI(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 10, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/SHIORI/SHIORI.png");
    }
}
