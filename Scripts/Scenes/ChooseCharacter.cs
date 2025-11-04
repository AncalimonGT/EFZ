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


        this.Characters.FirstOrDefault().IsSelected = true;
        //
    }


    public override void _Process(double delta)
    {





    }

    public override void _Input(InputEvent @event)
    {

        if (@event.IsActionPressed("ui_right"))
        {
            var c = this.Characters.Where(t => t.IsSelected).FirstOrDefault();

            c.IsSelected = false;

            var random = new Random();
            var index = random.Next(0, this.Characters.Count);
            this.Characters[index].IsSelected = true;
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }
}
