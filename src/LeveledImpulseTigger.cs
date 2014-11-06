using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWei.Triggers
{
    public class LeveledImpulseTigger
    {
        public LeveledImpulseTigger(int n,int inital = 0)
        {
            if (n > 0)
                _level = n;
            else
                throw new Exception(string.Format("Cannot set {0} level", n));
            if (inital < 0 || inital > n)
                throw new Exception(string.Format("Cannot set inital {0}", inital));
            else
                _times = inital;
        }

        public void Stimulating(Action aAction, int aStep = 1)
        {
            if (aStep < 0)
                return;
            var old = _times;
            _times = checked(aStep + old);
            if (_times > _level) _times = _level;
            if (old < _level && _times == _level)
            {
                _times = _level;
                if (aAction != null)
                    aAction();
            }
        }

        public void Relaxing()
        {
            Relaxing(null, -1);
        }

        public void Relaxing(Action aAction, int aStep = -1)
        {
            if (aStep > 0)
                return;
            var old = _times;
            _times = checked(aStep + old);
            if (_times < 0) _times = 0;
            if (old > 0 && _times == 0)
            {
                _times = 0;
                if (aAction != null)
                    aAction();
            }
        }

        public void Reset()
        {
            Reset(null);
        }

        public void Reset(Action aAction)
        {
            var old = _times;
            _times = 0;
            if (old > 0 && aAction != null)
                aAction();
        }

        public int State
        {
            get { return _times; }
        }

        private volatile int _times;
        private int _level;
    }
}
