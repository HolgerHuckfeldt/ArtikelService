namespace ArtikelService.Services
{
    public class ErrorMessages
    {
        public const string permission_fail = "Sie haben nicht die nötige Berechtigung um die Änderungen durchzuführen.";
        public const string message_vdb_notavailable = "Das Bestellsystem ist im Moment nicht erreichbar.<br> Evtl. werden keine Preise angezeigt.";
        public const string message_max_length_exceeded = "data is too long";
        public const string message_cannot_order_article = "Dieser Artikel kann nicht in den Warenkorb gelegt werden.";
        public const string message_no_standort = "Dieses Profil kann nicht aktiviert werden weil kein Standort hinterlegt ist";
        public const string message_no_articles_found = "Keine Artikel vorhanden.";
        public const string message_no_cars_found = "Keine Fahrzeuge vorhanden.";
        public const string message_no_vehicles_found = "Keine Fahrzeuge vorhanden.";
        public const string message_no_engines_found = "Keine Motoren vorhanden.";
        public const string message_no_axles_found = "Keine Achsen vorhanden.";
        public const string message_embedded_sqlscript_not_found = "Script für Datenbankabfrage nicht vorhanden";
        public const string message_temot_invalid = "Die Daten für die grafische Suche können nicht ermittelt werden.";
        public const string message_temot_invalid_graphic = "Das Bild für die grafische Suche konnte nicht geladen werden.";
        public const string message_profile_already_activated = "Dieses Profil wurde bereits aktiviert.";
        public const string message_no_plus_account_found = "Es konnten keine PV:PLUS Kontoinformationen gefunden werden.";
    }
}
