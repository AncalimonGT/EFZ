using EFZ.Scripts.Characters;
using Godot;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables.Fluent;

namespace EFZ.Scripts;

public partial class ChooseCharacter : NodeBase
{
    /// <summary>
    /// 背景
    /// </summary>
    public TextureRect Background { get; set; }


    /// <summary>
    /// p1选择框
    /// </summary>
    public TextureRect P1SelectBox { get; set; }


    /// <summary>
    /// 人物列表
    /// </summary>
    public List<CharacterBase> Characters { get; set; } = [];


    public ShaderMaterial Transparent { get; set; }

    public ChooseCharacter()
    {
        this.Transparent = new ShaderMaterial() { Shader = GD.Load<Shader>("res:///Shaders/transparent_shader.gdshader") };

        var size = this.DataRes.ChooseCharacter.Background.GetSize();

        this.Background = new TextureRect()
        {
            Texture = this.DataRes.ChooseCharacter.Background,
            Size = new Vector2(size.X * this.Zoom, size.Y * this.Zoom),
            Position = new Vector2(0, 0)
        };

        //初始化角色列表
        foreach (var subclass in Helpers.GetType<CharacterBase>())
        {
            var instance = (CharacterBase)Activator.CreateInstance(subclass);
            this.Characters.Add(instance);
        }

        size = this.DataRes.ChooseCharacter.P1SelectBox.GetSize();
        //创建一个1p选择框
        this.P1SelectBox = new TextureRect()
        {
            Texture = this.DataRes.ChooseCharacter.P1SelectBox,
            Size = new Vector2(size.X * this.Zoom, size.Y * this.Zoom),
            Material = this.Transparent,
            TextureFilter = CanvasItem.TextureFilterEnum.Nearest,
            Visible = false
        };
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.AddChild(this.Background);
        //  this.AddChild(this.Camera);

        //背景移动
        var targetPos = new Vector2(this.Background.Position.X, -this.Background.Size.Y / 2);

        var tween = this.GetTree().CreateTween();

        tween.TweenProperty(this.Background, "position", targetPos, 1f).SetEase(Tween.EaseType.In).SetTrans(Tween.TransitionType.Sine);

        //显示角色
        foreach (var character in this.Characters)
        {
            var res = character.Res.Avatar;
            var width = res.GetSize().X * this.Zoom;
            var height = res.GetSize().Y * this.Zoom;

            var x = (character.Row % 2 == 0 ? 394 : 370) + width * character.Column - character.Column * this.Zoom;
            var y = 20 + height * character.Row + character.Row * this.Zoom;

            var texture = new TextureRect()
            {
                Texture = res,
                Position = new Vector2(x, y),
                Size = new Vector2(width, height),
                Material = this.Transparent,
                TextureFilter = CanvasItem.TextureFilterEnum.Nearest
            };

            this.AddChild(texture);

            character.WhenAnyValue(t => t.IsSelected).Subscribe(@is =>
            {


                if (@is)
                {
                    //this.Characters.Where(t=>t.DisplayName != character.DisplayName).ForEach(t => t.IsSelected = false);

                    this.Log().Info("选择了" + character.DisplayName);
                    this.P1SelectBox.Position = new Vector2(x - 9 * this.Zoom, y);
                    this.P1SelectBox.Visible = true;
                }


            }).DisposeWith(this.Disposables);


        }

        this.AddChild(this.P1SelectBox);


        this.Characters.OrderBy(t => t.Row).ThenBy(t => t.Column).FirstOrDefault().IsSelected = true;
        //
    }


    public override void _Process(double delta)
    {





    }

    public void Selected(int x, int y)
    {
        var ch = this.Characters.Where(t => t.IsSelected).FirstOrDefault();

        var row = ch.Row + y;
        var col = ch.Column + x;

        if (row > 7)
        {
            row = 0;
        }
        else if (row < 0)
        {
            row = 7;
        }

        if (col > 2)
        {
            col = 0;
        }
        else if (col < 0)
        {
            col = 2;
        }

        this.Log().Info($"1row:{row}.col:{col}");

        ch.IsSelected = false;

        ch = this.Characters.Where(t => t.Row == row && t.Column == col).FirstOrDefault();

        if (ch != null)
        {
            this.Log().Info($"{ch.DisplayName}");
            ch.IsSelected = true;
        }
    }

    public override void _Input(InputEvent @event)
    {


        if (@event.IsActionPressed("ui_right"))
        {
            this.Selected(1, 0);
        }
        else if (@event.IsActionPressed("ui_left"))
        {
            this.Selected(-1, 0);
        }
        else if (@event.IsActionPressed("ui_up"))
        {
            this.Selected(0, -1);
        }
        else if (@event.IsActionPressed("ui_down"))
        {
            this.Selected(0, 1);
        }

    }
}
