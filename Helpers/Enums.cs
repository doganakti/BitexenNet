using System;
using System.ComponentModel;

namespace BitexenNet.Helpers;

public enum OrderStatus
{
    [Description("O")]
    Open = 0,

    [Description("C")]
    Closed = 1,

    [Description("A")]
    All = 2,
}

public enum OrderType
{
    [Description("limit")]
    Limit = 0,

    [Description("market")]
    Market = 1,
}

public enum OrderSide
{
    [Description("B")]
    Buy = 0,

    [Description("S")]
    Sell = 1,
}

