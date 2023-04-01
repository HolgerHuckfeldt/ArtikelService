using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Enums
{
    public enum SortMethod
    {
        /// <summary>
        /// Standard, auch dann wenn eine andere Methode gewählt wurde, aber kein SortField angegeben ist. (unsortiert, Sortierung macht Solr)
        /// </summary>
        Score,
        /// <summary>
        /// Normale aufsteigende Sortierung
        /// </summary>
        Ascending,
        /// <summary>
        /// Normale absteigende Sortierung
        /// </summary>
        Descending
    }
}
