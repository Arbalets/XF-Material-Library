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
            ErrorButton.Command = new Command(() =>
                {
                    TextField.ErrorText = string.IsNullOrEmpty(TextField.ErrorText) ? "This is error!" : null;
                });
        }
    }

    public abstract class BaseMainView : BaseView<MainViewModel> { }
}
