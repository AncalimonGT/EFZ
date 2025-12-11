using Godot;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Splat;

namespace EFZ.Scripts.Characters;

public abstract partial class CharacterBase : ReactiveObject
{
    public int Zoom => Locator.Current.GetService<AppDataCore>().ResourceZoom;
    public CharacterBase()
    {

    }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name => this.GetType().Name;

    /// <summary>
    /// 显示名
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// 行
    /// </summary>
    public abstract int Row { get; }

    /// <summary>
    /// 列
    /// </summary>
    public abstract int Column { get; }


    [Reactive]
    public partial bool IsSelected { get; set; }


    /// <summary>
    /// 头像
    /// </summary>
    public AtlasTexture Avatar { get; set; }


    /// <summary>
    /// 名牌
    /// </summary>
    public AtlasTexture NameBoard { get; set; }

    /// <summary>
    /// 立绘
    /// </summary>
    public Texture2D Illustration { get; set; }


    public Rect2 GetAvatarRegion()
    {
        var ml = this.Row % 2 == 0 ? 7 : 1;

        return new Rect2(ml + 41 * this.Column - this.Column, 10 + (25 + 1) * this.Row, 41 * this.Zoom, 25 * this.Zoom);
    }

}
