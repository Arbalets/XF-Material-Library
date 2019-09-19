using MaterialMvvmSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaterialMvvmSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : BaseMainView
    {
        public MainView()
        {
            this.InitializeComponent();

            DisableButton.Command = new Command(() => ErrorButton.IsEnabled = !ErrorButton.IsEnabled);
            ErrorButton.Command = new Command(() => TextField.HasError = !TextField.HasError);
        }

        private void TargetButton_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Button.IsEnabledProperty.PropertyName)
            {
                var button = (Button)sender;

                if (button.IsEnabled) button.TextColor = Color.Aqua;
            }
        }
    }

    public abstract class BaseMainView : BaseView<MainViewModel> { }
}
