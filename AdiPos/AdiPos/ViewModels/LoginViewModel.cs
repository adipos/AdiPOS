using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdiPos.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }

        public LoginViewModel(IScreen screen) => HostScreen = screen;
    }
}
