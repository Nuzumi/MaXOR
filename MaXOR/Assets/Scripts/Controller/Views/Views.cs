namespace Maxor.Views
{
    public interface IViews
    {

    }

    public class Views : IViews
    {
        private readonly IServices services;

        public Views(IServices services)
        {
            this.services = services;
        }
    }
}