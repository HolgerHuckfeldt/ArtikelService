using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Warenkorb.Transactions;

namespace PV.DomainObjects.Warenkorb
{
    [Serializable]
    public abstract class wkCommandPattern
    {
        /// <summary>
        /// Ein wkCommandPattern welches true liefert veranlasst den WarenkorbManager dazu, 
        /// den Commandstack abzuarbeiten. Kommt es zu problemen (in der Verbindung zur VDB z.B.) wird
        /// der entsprechende Command vom STack geschmissen.
        /// 
        /// PreviewCommand wird bei diesen Commands NIE aufgerufen
        /// </summary>
        public abstract Boolean FlushCommandStack
        {
            get;
        }

        /// <summary>
        /// Gibt an, ob der CommandStack zur ausführung dieses Commands zur Vorschau abgearbeitet werden soll.
        /// Bei Änderungen der Menge z.B. wird die VorschauPosition direkt vom Command manipuliert.
        /// </summary>
        public abstract Boolean PreviewCommandStack
        {
            get;
        }

        /// <summary>
        /// Führt den Command aus, indem es die Transaktion für die VDB entsprechend bearbeitet.
        /// </summary>
        /// <param name="_transaktionPositions">
        /// Transaktionen, die an die VDB geschickt werden soll.
        /// Ein Command darf zwar neue Transaktionen hinzufügen, jedoch keine aus der Liste Löschen.
        /// DomainObjects dürfen hier nicht hinzugefügt werden, jedoch gelöscht werden, wenn keine weiteren Transaktionsbearbeitungen erfolgen sollen.
        /// </param>
        public abstract void ExecCommand(IList<wkPosition> _Positions, List<wkPositionTransactionReq> _transaktions);


        /// <summary>
        /// Führt den Command an einer Copy des original DomainObjects aus, so kann das Ergebnis im Frontend angezeigt werden, 
        /// bevor VDB Transaktionen durchgeführt werden.
        /// </summary>
        /// <param name="_viewPosition">
        /// Liste von Kopien aller Positionen WK
        /// Es können DOs hinzugefügt und gelöscht werden.
        /// </param>
        public abstract void PreviewCommand(IList<wkPosition> _viewPositions, wkWarenkorb _warenkorb);
    }
}