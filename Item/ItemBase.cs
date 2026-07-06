using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Item;

public abstract class ItemBase
{
    public readonly int Id;
    public readonly string? Name;

    public ItemBase(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

