using EFZ.Models.Areas;
using EFZ.Scripts.Characters;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFZ.Scripts;

/// <summary>
/// 选择场景
/// </summary>
public partial class ChooseArea : NodeBase
{
    /// <summary>
    /// 预览
    /// </summary>
    public Texture2D Preview { get; set; }


    /// <summary>
    /// 背景
    /// </summary>
    public Texture2D Background { get; set; }


    /// <summary>
    /// 场景列表
    /// </summary>
    public List<AreaResBase> Areas { get; set; } = [];


}

