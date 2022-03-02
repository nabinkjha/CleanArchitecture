namespace ToastNotification.Toastify.Models
{
    public class ToastifyConfig
    {
        public int DurationInSeconds { get; set; }
        public ToastNotification.Position Position { get; set; } = Position.Right;
        public Gravity Gravity { get; set; } = Gravity.Bottom;
    }
}
