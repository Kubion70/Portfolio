namespace Portfolio.Core.LogicAbstractions
{
    public interface ILogicRequest<out Result>
        where Result : ILogicResult
    {
    }
}