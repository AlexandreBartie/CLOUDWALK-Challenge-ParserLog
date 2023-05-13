using parser.core.log;
using parser.data.view;

namespace parser.data.panel;

public abstract class PanelView
{
    public LogList logs => view.logs.filter(type);

    public int count => logs.Count;

    public readonly PanelData view;

    public readonly LogType type;

    public PanelView(PanelData view, LogType type)
    {
        this.view = view;

        this.type = type;
    }
}