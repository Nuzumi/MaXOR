namespace Maxor.Views
{
    public interface IViews
    {
        IMenuView MenuView { get; }
    }

    public class Views : IViews
    {
        private readonly IServices services;

        public IMenuView MenuView {get; private set; }

        public Views(IServices services)
        {
            this.services = services;

            InitViews();
        }

        private void InitViews()
        {
            MenuView = new MenuView(services, this);
        }
    }
}