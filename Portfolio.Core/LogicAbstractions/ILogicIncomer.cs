namespace Portfolio.Core.LogicAbstractions
{
    public interface ILogicIncomer<out Result>
        where Result : ILogicResult
    {
    }
}
