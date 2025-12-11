using EFZ.Models.Areas;
using Godot;
using System;

namespace EFZ.Scripts.Res;

public class ChooseAreaRes : ResBase
{
    /// <summary>
    /// 背景
    /// </summary>
    public Texture2D Background { get; set; }


    /// <summary>
    /// 对象
    /// </summary>
    public Texture2D AllObject { get; set; }


    public override void Load()
    {

        //foreach (var item in Helpers.GetType<AreaResBase>())
        //{
        //    var @obj = (AreaResBase)Activator.CreateInstance(item, [this.Object]);

        //    this.CharactersRes.Add(@obj);

        //}

        this.Background = ResBase.LoadRes<Texture2D>("SYSTEM/chr_sel_bg.png");
    }
}
