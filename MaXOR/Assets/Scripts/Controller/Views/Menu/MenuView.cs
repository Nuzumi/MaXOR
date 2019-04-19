using Maxor.Model.View;

namespace Maxor.Views
{
    public interface IMenuView : IView
    {

    }

    public class MenuView : View<MenuViewComponent>, IMenuView
    {
        public MenuView(IServices services, IViews views) : base(services, views)
        {
            refs.welcomeText.text = "Kekeke";
            Show();
        }
    }
}