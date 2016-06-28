using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.core
{
    class Enums
    {
    }

    public enum ActionMode
    {
        Hessian = 1,
        ICE = 2
    }

    public enum DictionaryType
    {
        Organization = 100,
        Function = 101
    }

    public enum EditType
    {
        Add,
        AddChild,
        AddRoot,
        Update,
        Delete
    }
}
