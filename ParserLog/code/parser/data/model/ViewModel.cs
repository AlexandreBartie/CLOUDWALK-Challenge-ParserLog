using parser.core.log;
using parser.data.view;

namespace parser.data.model;

public abstract class ViewModel
{
    public LogList logs => view.logs.filter(type);

    public int count => logs.Count;

    public readonly ViewDashBoard view;

    public readonly LogType type;

    public ViewModel(ViewDashBoard view, LogType type)
    {
        this.view = view;

        this.type = type;
    }
}