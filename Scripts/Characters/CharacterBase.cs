using EFZ.Scripts.Res.Characters;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.SourceGenerators;

namespace EFZ.Scripts.Characters;

public abstract partial class CharacterBase : ReactiveObject
{
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
    public CharacterBase()
    {
        this.Res = this.DataRes.ChooseCharacter.CharactersRes.FirstOrDefault(t => t.Name == $"{this.GetType().Name}Res");
    }
    protected DataRes DataRes => Locator.Current.GetService<DataRes>();

    public CharactersResBase Res { get; set; }

    [Reactive]
    public partial bool IsSelected { get; set; }


}
