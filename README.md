# How to customize the header view of Calendar in Xamarin.Forms (SfCalendar) ?

You can change the header view by setting the content to CalendarHeaderEventArgs.View property in OnHeaderLoaded event.

**C#**
``` c#
private void OnHeaderLoaded(object sender, CalendarHeaderEventArgs e)
{
    Grid grid = new Grid();
    grid.BackgroundColor = Color.FromHex("#E0CCFF");
    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
    Image leftImage = new Image();
    leftImage.Source = "Left.png";
    Image rightImage = new Image();
    rightImage.Source = "Right.png";
    TapGestureRecognizer leftTap = new TapGestureRecognizer();
    TapGestureRecognizer rightTap = new TapGestureRecognizer();
    leftImage.GestureRecognizers.Add(leftTap);
    rightImage.GestureRecognizers.Add(rightTap);
    leftTap.Tapped += OnLeftHandleAction;
    rightTap.Tapped += OnRightHandleAction;
    Label label = new Label();
    label.SetBinding(Label.TextProperty, "SelectedMonth");
    label.FontSize = 18;
    label.HorizontalOptions = LayoutOptions.Center;
    label.VerticalOptions = LayoutOptions.Center;
    grid.Children.Add(leftImage, 0, 0);
    grid.Children.Add(label, 1, 0);
    grid.Children.Add(rightImage, 2, 0);
    e.View = grid;
}
```

**Output**

![CustomHeaderView](https://github.com/SyncfusionExamples/customview-on-header-loaded-calendar-xamarin/blob/master/ScreenShots/CutomHeaderView.png)
