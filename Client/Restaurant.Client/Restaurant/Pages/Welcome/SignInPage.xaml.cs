using System.Threading.Tasks;
using Restaurant.Abstractions.Managers;
using Restaurant.ViewModels;
using Xamarin.Forms;

namespace Restaurant.Pages
{
    public partial class SignInPage : SignInPageXaml
    {
        public SignInPage(IThemeManager themeManager)
        {
            InitializeComponent();
            var theme = themeManager.GetThemeFromColor("red");
            StatusBarColor = theme.Dark;
            ActionBarBackgroundColor = theme.Primary;
            //SignInViewModel.Login.Subscribe(async x =>
            //{
            //    await AnimateControls(0, Easing.SinOut);
            //    SignInViewModel.NavigateToMainPage(x);
            //    SignInViewModel.IsBusy = false;
            //});                 
        }

        private async Task AnimateControls(int scale, Easing easing)
        {
            await emailStack.ScaleTo(scale, App.AnimationSpeed, easing);
            await passwordStack.ScaleTo(scale, App.AnimationSpeed, easing);
            await loginStack.ScaleTo(scale, App.AnimationSpeed, easing);
        }

        protected override async void OnLoaded()
        {
            BindingContext = ViewModel;
            await AnimateControls(1, Easing.SinIn);
        }
    }

    public abstract class SignInPageXaml : BaseContentPage<SignInViewModel>
    {

    }
}