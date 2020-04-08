using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Localization;

namespace Avtorentovik
{
    public class MyGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FindControlFindButton:
                    return "Найти";
                case GridStringId.FindControlClearButton:
                    return "Очистить";
                case GridStringId.FilterPanelCustomizeButton:
                    return "Фильтр";                    
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
