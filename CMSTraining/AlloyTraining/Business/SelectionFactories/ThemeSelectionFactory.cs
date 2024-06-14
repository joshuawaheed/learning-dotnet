using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace AlloyTraining.Business.SelectionFactories
{
    public class ThemeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            yield return new SelectItem { Value = "theme1", Text = "Orange" };
            yield return new SelectItem { Value = "theme2", Text = "Purple" };
            yield return new SelectItem { Value = "theme3", Text = "Green" };
        }
    }
}
