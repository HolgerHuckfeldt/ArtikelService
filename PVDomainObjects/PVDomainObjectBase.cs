using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PV.DomainObjects
{
    [DataContract]
    [Serializable]
    public abstract class PVDomainObjectBase
    {
        static private Dictionary<Object,String>  _ObjectClasses = new Dictionary<Object, String>();
        static private Dictionary<Object,Type>    _UserDataTypes = new Dictionary<Object, Type>();

        static public void RegisterUserDataTyp(Object owner,Type userDataTyp)
        {
            //Ein Objekt darf nur einen User Datatypen registrieren
            if(!_UserDataTypes.ContainsKey(owner))
            {
                _UserDataTypes.Add(owner,userDataTyp);
            }
        }

        static public void RegisterClassDataTyp(Object owner, Type userDataTyp, String className)
        {
            //Ein Objekt (Manager, Intelligente Liste etc.) darf sich nicht in einer Class registrieren
            //wenn es schon ohne registriert ist.
            if (!_UserDataTypes.ContainsKey(owner))
            {
                //Ein Objekt (Manager, Intelligente Liste etc.) darf zu maximal EINER Class gehören
                if (!_ObjectClasses.ContainsKey(owner))
                {
                    _ObjectClasses.Add(owner,className);
                }
                _UserDataTypes.Add(owner, userDataTyp);
            }
        }

        private Dictionary<Object, Object> _UserData;
        private Dictionary<Object,Int32> _UserReferenzen;

        public void ReleaseUserReferenz(Object owner)
        {
            if (!_UserDataTypes.ContainsKey(owner))
            {
                throw new Exception("Ein Objekt muss erst einen Datentypen für die UserData und ggf. eine Class Registrieren, bevor es eine UserReferenz an ein Domain Object hängen bzw. entfernen kann!");
            }
            if (!_UserData.ContainsKey(owner))
            {
                throw new Exception("Es wurde versucht, mehr Referenzen eines Owner-Objekts aus der Referenzliste zu entferenen als hinzugefügt wurden!");
            }
            if (!_UserReferenzen.ContainsKey(owner) || _UserReferenzen[owner] < 1)
            {
                throw new Exception("Interner fehler in der Referenzzählung");
            }
            --_UserReferenzen[owner];
            if(_UserReferenzen[owner] == 0)
            {
                _UserReferenzen.Remove(owner);
                _UserData.Remove(owner);
            }
        }

        public void AddUserReferenz(Object owner)
        {
            if (_UserData == null)
                _UserData = new Dictionary<object, object>();
            if(_UserReferenzen == null)
                _UserReferenzen = new Dictionary<object, int>();

            //gehört der Owner zu einer Class?
            if(!_UserDataTypes.ContainsKey(owner))
            {
                throw new Exception("Ein Objekt muss erst einen Datentypen für die UserData und ggf. eine Class Registrieren, bevor es eine UserReferenz an ein Domain Object hänegen bzw. entfernen kann!");
            }
            if(_ObjectClasses.ContainsKey(owner))
            {
                if (!_UserData.ContainsKey(owner))
                {
                    String _class = _ObjectClasses[owner];
                    var oc = (from u in _UserData where _ObjectClasses.ContainsKey(u.Key) select u).FirstOrDefault();
                    if (oc.Value != null)
                    {

                        _UserData.Add(owner, oc.Value);
                    }

                    else
                    {
                        Type userDataTyp = _UserDataTypes[owner];
                        Object userData = Activator.CreateInstance(userDataTyp);
                        _UserData.Add(owner, userData);
                    }
                }
            }
            else if (!_UserData.ContainsKey(owner))
            {
                Type userDataTyp = _UserDataTypes[owner];
                Object userData = Activator.CreateInstance(userDataTyp);
                _UserData.Add(owner, userData);
            }

            if(!_UserReferenzen.ContainsKey(owner))
            {
                _UserReferenzen.Add(owner,0);
            }

            ++_UserReferenzen[owner];
        }

        public Object AccesUserData(Object owner)
        {
            if (!_UserDataTypes.ContainsKey(owner))
            {
                throw new Exception("Ein Objekt muss erst einen Datentypen für die UserData und ggf. eine Class Registrieren, bevor es eine UserReferenz an ein Domain Object hängen bzw. entfernen kann!");
            }
            if (!_UserData.ContainsKey(owner))
            {
                throw new Exception("Es wurde versucht, mehr Referenzen eines Owner-Objekts aus der Referenzliste zu entferenen als hinzugefügt wurden!");
            }
            if (!_UserReferenzen.ContainsKey(owner) || _UserReferenzen[owner] < 1)
            {
                throw new Exception("Interner fehler in der Referenzzählung");
            }
            return _UserData[owner];
        }

    }
}
