using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Voice_Modulation
{
    class Voice_Modulation
    {
        //matlab dll file 
        //AudioPitchShiftNative.Class1 psn = new Class1();
        public MLApp.MLApp matlab = new MLApp.MLApp();

        public void realtime_mod(int mod_val)
        {
            matlab.Execute(@"cd C:\Users\LeeHonggu\Documents\GitHub\real-time-mosaic-and-voice-modulation\audioMatlab");

            var shift_val = 0;
            object result = null;

            matlab.Feval("AudioPitchShift", 0, out result, shift_val);

            if (mod_val == 1)
            {
                shift_val = 7;
            }
            else
            {
                shift_val = 0;
            }
        }

        //public void modulation()
        //{
        //    var shift_val = 7;
        //    psn.AudioPitchShift(shift_val);
        //}

        //public void realtime()
        //{
        //    var shift_val = 0;
        //    psn.AudioPitchShift(shift_val);
        //}
    }
}
