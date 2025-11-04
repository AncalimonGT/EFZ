using EFZ.Scripts.Res;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts;

public class DataRes
{
    public MainMenuRes MainMenu { get; set; }

    public ChooseCharacterRes ChooseCharacter { get; set; }

    public DataRes()
    {
        MainMenu = new MainMenuRes();
        ChooseCharacter = new ChooseCharacterRes();
    }


    public void ReLoad()
    {
        this.MainMenu.Load();
        this.ChooseCharacter.Load();
    }
}

