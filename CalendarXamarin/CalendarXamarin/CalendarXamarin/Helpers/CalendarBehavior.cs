using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CalendarXamarin
{
    internal class CalendarBehavior : Behavior<ContentPage>
    {
        ViewModel viewModel;
        SfCalendar calendar;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            viewModel = bindable.BindingContext as ViewModel;
            calendar = bindable.FindByName<SfCalendar>("calendar");
            calendar.MonthChanged += OnMonthChanged;
            calendar.OnHeaderLoaded += OnHeaderLoaded;
        }

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

        private void OnRightHandleAction(object sender, EventArgs e)
        {
            calendar.Forward();
        }

        private void OnLeftHandleAction(object sender, EventArgs e)
        {
            calendar.Backward();   
        }

        private void OnMonthChanged(object sender, MonthChangedEventArgs e)
        {
            viewModel.SelectedMonth = e.CurrentValue.ToString("Y");
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar.MonthChanged -= OnMonthChanged;
            calendar = null;
        }
    }
}
