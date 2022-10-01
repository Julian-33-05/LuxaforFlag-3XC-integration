using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp;
using Microsoft.Win32;
using static System.TimeZoneInfo;

namespace FlagTest
{
    public class FlagHandler : IDisposable
    {
        private const int TransitionTime = 7;
        readonly IDevice device;

        public FlagHandler()
        {
            IDeviceList list = new DeviceList();
            list.Scan();
            device = list.First() ?? throw new ApplicationException("Could not find a device");
        }

        public void Standup()
        {
            device.CarryOutPattern(PatternType.RainbowWave, 1).Wait();
        }

        public void SetIsFocussed()
        {
            Color flagColor = Colors.Red;
            device.SetColor(LedTarget.All, flagColor, TransitionTime);
        }

        public void SetIsNotFocussed()
        {
            Color flagColor = Colors.Green;
            device.SetColor(LedTarget.All, flagColor, TransitionTime);
        }

        private void TurnOffDevice()
        {
            device.SetColor(LedTarget.AllFrontSide, Colors.Off, TransitionTime).Wait();
            device.SetColor(LedTarget.AllBackSide, Colors.Off, TransitionTime).Wait();
        }

        #region IDisposable Support
        public void Dispose()
        {
            TurnOffDevice();
            device.Dispose();
        }
        #endregion
    }
}
