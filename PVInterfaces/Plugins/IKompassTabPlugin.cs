using System;
using PVInterfaces.Enums;

using System.Collections.Generic;

namespace PVInterfaces.Plugins
{
    public interface IKompassTabPlugin 
        : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gibt an, ob das Plugin bereits initialisiert wurde
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Liefert den einzufügenden Tab zurück.
        /// </summary>
        /// <returns></returns>
        //TabItem Tab { get; }

        /// <summary>
        /// Liefert die Einfügeposition für den Tab zurück.
        /// </summary>
        KompassTabInsertPosition InsertPosition { get; }

        /// <summary>
        /// Liefert die Plugin-Versionsnummer
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Liefert die Bezeichnung des Plugins
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Liefer eine Kurzbeschreibung des Plugins
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gibt an ob der Tab des Plugins angezeigt werden soll
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Liefert einen Status-Text des Plugins.
        /// </summary>
        string State { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Initialisiert die aktuelle Instanz.
        /// </summary>
        /// <returns><code>true</code> wenn die Initialisierung fehlerfrei verlaufen ist, sonst <code>false</code></returns>
        //bool Initialize(IServicePool servicePool, IEventBroker eventBroker);

        #endregion
    }
}
