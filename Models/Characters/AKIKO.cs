using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;

namespace EFZ.Models.Characters;

public class AKIKO : CharacterBase
{
    public AKIKO(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 15, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/AKIKO/AKIKO.png");
    }

    public override string DisplayName => "水濑秋子";

    public override int Row => 7;

    public override int Column => 0;

}
