using EFZ.Scripts;
using Godot;
using Splat;

namespace EFZ.Models.Areas;

public abstract class AreaResBase
{
    public int Zoom => Locator.Current.GetService<AppDataCore>().ResourceZoom;

    /// <summary>
    /// 名字
    /// </summary>
    public string Name => GetType().Name;

    /// <summary>
    /// 名牌
    /// </summary>
    public AtlasTexture NameBoard { get; set; }


    /// <summary>
    /// 激活的名牌
    /// </summary>
    public AtlasTexture NameBoardSelected { get; set; }

    /// <summary>
    /// 显示名
    /// </summary>
    public abstract string DisplayName { get; }
}
