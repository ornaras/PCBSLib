using System;

namespace PCBS
{
    [Flags]
    public enum PCBSConnTypes : byte
    {
        COM = 1,
        HID = 2
    }
}
