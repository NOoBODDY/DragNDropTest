using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Xaml.Interactions.DragAndDrop;

namespace DragNDropTest.Behaviors;

public class CanvasDropHandler: DropHandlerBase
{

    public override bool Validate(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (sender is not Canvas)
            return false;
        if (sourceContext is not ItemModel)
            return false;

        return true;
    }

    public override bool Execute(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (sender is not Canvas canvas)
            return false;
        if (sourceContext is not ItemModel itemModel)
            return false;

        var menu = new MenuFlyout()
        {
            Placement = PlacementMode.Pointer
        };
        for (int i = 0; i < 3; i++)
        {
            menu.Items.Add(new MenuItem() { Header = itemModel.Value + i });
        }
        menu.ShowAt(canvas, true);
        return true;
    }
}