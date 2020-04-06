
namespace MBAM.Annotations.Domain.Annotations.Commands
{
    public class RegisterAnnotationCommand : BaseAnnotationCommand
    {
        public RegisterAnnotationCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
