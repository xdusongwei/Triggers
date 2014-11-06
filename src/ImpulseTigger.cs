using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace SongWei.Triggers
{
    public class ImpulseTigger
    {
        public ImpulseTigger():this(false)
        {

        }
        public ImpulseTigger(bool aInitValue)
        {
            _state = aInitValue;
        }

        public void Trigging(Action aAction)
        {
            var old = _state;
            _state = true;
            if (_state ^ old && aAction != null)
                aAction();
        }

        public void Reset()
        {
            Reset(null);
        }

        public void Reset(Action aAction)
        {
            var old = _state;
            _state = false;
            if (_state ^ old && aAction != null)
                aAction();
        }

        public bool State
        {
            get { return _state; }
        }

        private volatile bool _state = false;

    }
}
