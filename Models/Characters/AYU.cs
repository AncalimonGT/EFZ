using EFZ.Scripts.Characters;
using EFZ.Scripts.Res;
using Godot;

namespace EFZ.Models.Characters;

public class AYU : CharacterBase
{
    public override string DisplayName => "月宫亚由";

    public override int Row => 2;

    public override int Column => 0;


    public AYU(Texture2D @object) 
    {
        this.Avatar = new AtlasTexture()
        {
            Atlas = @object,
            Region = this.GetAvatarRegion()
        };

        this.NameBoard = new AtlasTexture()
        {
            Atlas = @object,
            Region = new Rect2(0, 256 + 32 * 7, 122 * Zoom, 32 * Zoom)
        };

        this.Illustration = ResBase.LoadRes<Texture2D>("SYSTEM/AYU/AYU.png");
    }

}