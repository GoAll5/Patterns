using System;

namespace State
{
    interface IState
    {
        void ActionOnPressUp();
        void ActionOnPressDown();
        void ActionOnPressBlock();
    }
    class Phone
    {
        private IState _state;

        public Phone(IState s)
        {
            ChangeState(s);
        }

        public void ChangeState(IState s)
        {
            _state = s;
        }
        public void ActionOnPressUp() => _state.ActionOnPressUp();
        public void ActionOnPressDown() => _state.ActionOnPressDown();
        public void ActionOnPressBlock() => _state.ActionOnPressBlock();
    }

    abstract class PhoneState : IState
    {
        protected Phone _phone;

        protected PhoneState(Phone p = null)
        {
            SetPhone(p);
        }

        public void SetPhone(Phone p)
        {
            _phone = p;
        }
        public abstract void ActionOnPressBlock();

        public abstract void ActionOnPressDown();

        public abstract void ActionOnPressUp();
    }
    class BlockedState : PhoneState
    {
        public BlockedState(Phone p = null) : base(p)
        { }

        public override void ActionOnPressBlock()
        {
            _phone.ChangeState(new UnblockedState(_phone));
        }

        public override void ActionOnPressDown()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Unsupported operation");
        }

        public override void ActionOnPressUp()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Unsupported operation");
        }
    }

    class UnblockedState : PhoneState
    {
        public UnblockedState(Phone p) : base(p)
        { }
        public override void ActionOnPressBlock()
        {
            _phone.ChangeState(new BlockedState(_phone));
        }

        public override void ActionOnPressDown()
        {
            Console.WriteLine("Volume Up");
        }

        public override void ActionOnPressUp()
        {
            Console.WriteLine("Volume Down");
        }
    }
    class State
    {
        static void Main(string[] args)
        {
            
            var initialState = new BlockedState();
            var phone = new Phone(initialState);
            initialState.SetPhone(phone);

            phone.ActionOnPressUp();
            phone.ActionOnPressBlock();
            phone.ActionOnPressUp();
        }
    }
}
