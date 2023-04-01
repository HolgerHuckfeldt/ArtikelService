using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Technik
{
    public static class TechnikSuchbaumHelper
    {
        public static TechnikSuchbaumEintrag CreateHauptgruppeEintrag(int position)
        {
            EnumHauptgruppe.Hauptgruppe hg = EnumHauptgruppe.GetHauptgruppeZuPosition(position);
            return CreateHauptgruppeEintrag(hg,position);
        }
        public static TechnikSuchbaumEintrag CreateHauptgruppeEintrag(EnumHauptgruppe.Hauptgruppe hg,int sort)
        {
            TechnikSuchbaumEintrag tse = new TechnikSuchbaumEintrag();
            tse.Id = (int)hg;
            tse.Tiefe = 1;
            tse.Bezeichnung = EnumGruppe.ToString(hg);
            tse.Sortierung = sort;
            tse.EnumWert = hg;

            return tse;
        }
        public static TechnikSuchbaumEintrag CreateUntergruppeEintrag(EnumHauptgruppe.Hauptgruppe parent, int position)
        {
            EnumUntergruppe.Untergruppe ug = EnumUntergruppe.Untergruppe.NICHT_RELEVANT;
            switch (parent)
            {
                case EnumHauptgruppe.Hauptgruppe.MOTOR:
                    ug = EnumUntergruppe.GetEnumUntergruppeMotorZuPosition(position);
                    break;
                case EnumHauptgruppe.Hauptgruppe.BREMSEN:
                    ug = EnumUntergruppe.GetEnumUntergruppeBremsenZuPosition(position);
                    break;
                case EnumHauptgruppe.Hauptgruppe.LENKUNG_UND_RADAUFHÄNGUNG:
                    ug = EnumUntergruppe.GetEnumUntergruppeLenkungUndRadaufhaengungZuPosition(position);
                    break;
                case EnumHauptgruppe.Hauptgruppe.GETRIEBE:
                    ug = EnumUntergruppe.GetEnumUntergruppeGetriebeZuPosition(position);
                    break;
                case EnumHauptgruppe.Hauptgruppe.AUßENSEITE_UND_INNENRAUM:
                    ug = EnumUntergruppe.GetEnumUntergruppeAussenseiteUndInnenraumZuPosition(position);
                    break;
                default:
                    break;
            }
            return CreateUntergruppeEintrag(parent, ug, position);
        }
        public static TechnikSuchbaumEintrag CreateUntergruppeEintrag(EnumHauptgruppe.Hauptgruppe parent, EnumUntergruppe.Untergruppe ug, int sort)
        {
            TechnikSuchbaumEintrag tse = new TechnikSuchbaumEintrag();
            tse.Id = (int)ug;
            tse.Tiefe = 2;
            tse.Bezeichnung = EnumGruppe.ToString(ug);
            tse.Sortierung = sort;
            tse.EnumWert = ug;
            tse.Parent = (int)parent;

            return tse;
        }

        public static TechnikSuchbaumEintrag CreateEintrag(int tiefe, EnumUntergruppe.Untergruppe parent, EnumUntergruppe.Untergruppe ug, int ugID, int sort)
        {
            TechnikSuchbaumEintrag tse = new TechnikSuchbaumEintrag();
            tse.Id = ugID;
            tse.Tiefe = tiefe;
            tse.Bezeichnung = "(not set)";
            tse.Sortierung = sort;
            tse.EnumWert = ug;
            tse.Parent = (int)parent;

            return tse;
        }
        public static TechnikSuchbaumEintrag CreateEintrag(int tiefe, int parentID, EnumUntergruppe.Untergruppe ug, int ugID, int sort)
        {
            TechnikSuchbaumEintrag tse = new TechnikSuchbaumEintrag();
            tse.Id = ugID;
            tse.Tiefe = tiefe;
            tse.Bezeichnung ="(not set)";
            tse.Sortierung = sort;
            tse.EnumWert = ug;
            tse.Parent = parentID;

            return tse;
        }

    }
}
