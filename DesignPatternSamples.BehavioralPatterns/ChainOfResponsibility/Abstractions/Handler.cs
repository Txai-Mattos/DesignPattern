namespace DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions
{
    public abstract class Handler : IHandler
    {
        protected IHandler _nextHandle;

        public virtual void Execute(Context context)
        {
            if (_nextHandle != default)
                _nextHandle.Execute(context);
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandle = handler;
            return handler;
        }

    }
}
