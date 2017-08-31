public abstract class SubJect
{
    public SubJect()
    {
        finish = false;
    }

    public bool finish { get; private set; }

    abstract public void Run();

    CallBack SubEvent;
    public void Sub(CallBack call)
    {
        SubEvent += call;
    }

    protected void Notify()
    {
        finish = true;
        if (SubEvent != null)
        {
            SubEvent();
        }
        SubEvent = null;
    }
}