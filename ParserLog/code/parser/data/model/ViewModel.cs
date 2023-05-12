using parser.core.log;
using parser.data.view;

namespace parser.data.model;

public abstract class ViewModel
{
    public LogList logs => view.logs.filter(type);

    public int count => logs.Count;

    public readonly ViewData view;

    public readonly LogType type;

    public ViewModel(ViewData view, LogType type)
    {
        this.view = view;

        this.type = type;
    }

    public abstract string log(string label);

}