using Godot;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFZ.Scripts.Res.Characters;

/// <summary>
/// 角色资源基类
/// </summary>
public abstract class CharactersResBase
{
    public int Zoom => Locator.Current.GetService<AppDataCore>().ResourceZoom;

    /// <summary>
    /// 头像
    /// </summary>
    public AtlasTexture Avatar { get; set; }

    /// <summary>
    /// 名字
    /// </summary>
    public string Name => this.GetType().Name;

    /// <summary>
    /// 显示名
    /// </summary>
    public abstract string DisplayName { get; }

    /// <summary>
    /// 名牌
    /// </summary>
    public AtlasTexture NameBoard { get; set; }

    /// <summary>
    /// 立绘
    /// </summary>
    public Texture2D Illustration { get; set; }


    public Rect2 GetAvatarRegion(int row, int column)
    {
        var ml = row % 2 == 0 ? 7 : 1;



        return new Rect2(ml + 41 * column - column, 10 + (25 + 1) * row, 41 * this.Zoom, 25 * this.Zoom);
    }
}
