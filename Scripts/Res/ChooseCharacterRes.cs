using EFZ.Scripts.Characters;
using Godot;
using System;
using System.Collections.Generic;

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
    /// P1选择框
    /// </summary>
    public AtlasTexture P1SelectBox { get; set; }


    /// <summary>
    /// P1名字板
    /// </summary>
    public AtlasTexture P1NameBoard { get; set; }


    public AtlasTexture P1SelectBar { get; set; }

    public override void Load()

    { 
        this.Background = ResBase.LoadRes<Texture2D>("SYSTEM/chr_sel_bg.png");
        this.Object = ResBase.LoadRes<Texture2D>("SYSTEM/chr_sel_ob.png");


        this.P1SelectBox = new AtlasTexture()
        {
            Atlas = this.Object,
            Region = new Rect2(129, 0, 49 * this.Zoom, 24 * this.Zoom)
        };

        this.P1NameBoard = new AtlasTexture()
        {
            Atlas = this.Object,
            Region = new Rect2(192, 9, 122 * this.Zoom, 95 * this.Zoom)
        };

        this.P1SelectBar = new AtlasTexture()
        {
            Atlas = this.Object,
            Region = new Rect2(135, 128, 18 * this.Zoom, 240 * this.Zoom)
        };
    }
}