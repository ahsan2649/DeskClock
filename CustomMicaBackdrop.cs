using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desklock
{
    internal class CustomMicaBackdrop : SystemBackdrop
    {
        MicaController micaController;

        protected override void OnTargetConnected(ICompositionSupportsSystemBackdrop connectedTarget, XamlRoot xamlRoot)
        {
            // Call the base method to initialize the default configuration object.
            base.OnTargetConnected(connectedTarget, xamlRoot);

            // This example does not support sharing MicaSystemBackdrop instances.
            if (micaController is not null)
            {
                throw new Exception("This controller cannot be shared");
            }

            micaController = new MicaController();
            // Set configuration.
            micaController.Kind = MicaKind.BaseAlt;
            SystemBackdropConfiguration defaultConfig = new SystemBackdropConfiguration();
            micaController.SetSystemBackdropConfiguration(defaultConfig);
            // Add target.
            micaController.AddSystemBackdropTarget(connectedTarget);
        }

        protected override void OnTargetDisconnected(ICompositionSupportsSystemBackdrop disconnectedTarget)
        {
            return;
        }
    }
}
