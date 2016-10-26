using System.Collections.Generic;

namespace PlanetHeartPCL.Presentation
{
    public interface IBrowserView
    {
        void Display(List<PresentationItem> presentationItems);
    }
}