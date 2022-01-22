using System;
namespace FinalProlect.main
{
    public enum Amount
    {
        Ten, MinusOne, Zero, Five, Twenty, ThirtyFive, MinusFive
    }
    public static class enumAmount
    {
       
        public static string EnterAmount(this Amount me)
        {
            switch(me)
            {
                case Amount.Ten:
                    return "10";
                case Amount.MinusOne:
                    return "-1";
                case Amount.Zero:
                    return "0";
                case Amount.Five:
                    return "5";
                case Amount.Twenty:
                    return "20";
                case Amount.ThirtyFive:
                    return "35";
                case Amount.MinusFive:
                    return "-5";
                default:
                    return "No amount";
            }

        }
    }
}
