using parser.data.log;

namespace parser.data.model;

public abstract class ViewModelGeneric : ViewModel
{
    public LogList logs => view.logs.filter(type);

    public int count => logs.Count;

    public ViewModelGeneric(ViewData view, LogType type) : base(view, type) { }

    public abstract void GroupData();

    public abstract string log(string label);

}