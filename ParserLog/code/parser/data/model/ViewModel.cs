using parser.data.log;

namespace parser.data.model;

public abstract class ViewModel
{
    public readonly ViewData view;

    public readonly LogType type;

    public ViewModel(ViewData view, LogType type)
    {
        this.view = view;

        this.type = type;
    }

}