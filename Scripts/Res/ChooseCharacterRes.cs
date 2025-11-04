using EFZ.Scripts.Res.Characters;
using Godot;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts.Res;

public class ChooseCharacterRes : ResBase
{
    /// <summary>
    /// 背景
    /// </summary>
    public Texture2D Background { get; set; }

    /// <summary>
    /// 对象
    /// </summary>
    public Texture2D Object { get; set; }

    /// <summary>
    /// 角色资源
    /// </summary>
    public List<CharactersResBase> CharactersRes { get; set; }

    /// <summary>
    /// P1选择框
    /// </summary>
    public AtlasTexture P1SelectBox { get; set; }



    public override void Load()
    {
        this.CharactersRes = [];

        this.Background = this.LoadRes<Texture2D>("SYSTEM/chr_sel_bg.png");
        this.Object = this.LoadRes<Texture2D>("SYSTEM/chr_sel_ob.png");

        foreach (var item in Helpers.GetType<CharactersResBase>())
        {
            var @obj = (CharactersResBase)Activator.CreateInstance(item, [this.Object]);

            this.CharactersRes.Add(@obj);

        }

        this.P1SelectBox = new AtlasTexture()
        {
            Atlas = this.Object,
            Region = new Rect2(129, 0, 49 * this.Zoom, 24 * this.Zoom)
        };
    }
}