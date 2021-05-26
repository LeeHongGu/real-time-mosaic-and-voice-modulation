using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioPitchShiftNative;

namespace mosaic_modulation_project
{
    class voice_mod
    {
        AudioPitchShiftNative.Class1 psn = new Class1();

        public void modulation()
        {
            var shift_val = 7;
            psn.AudioPitchShift(shift_val);
        }

        public void realtime()
        {
            var shift_val = 0;
            psn.AudioPitchShift(shift_val);
        }
    }
}
