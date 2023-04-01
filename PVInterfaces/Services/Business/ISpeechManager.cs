using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.TemotDosi;
using System.Collections.ObjectModel;

namespace PV.Business.Services
{

    public delegate void SpeechResultEvent(string text);


    public interface ISpeechManager
    {
        void Start(int deviceIndex, int intention, Guid id);
        void Start(string deviceName, int intention, Guid id);

        void Start(int intention, Guid id);

        void Stop();

        string RecordDevice { set; get; }

        List<string> GetDeviceNames();

        bool UseSpeech();

        event SpeechResultEvent OnSpeechResult;
    }
}
