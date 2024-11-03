
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BadBadWolfEngine.Controlls
{

    public struct Input
    {
        private Microsoft.Xna.Framework.Input.Keys value;
        private bool state;

        public void SetInput( Microsoft.Xna.Framework.Input.Keys definedValue, bool startingState)
        {
            this.value = definedValue;
            this.state = startingState;
        }

        public Microsoft.Xna.Framework.Input.Keys getValue()
        {
            return this.value;
        }

        public bool getState()
        {
            return this.state;
        }

        public void newState(bool newState)
        {
            this.state = newState;
        }
    }

    public class Controller
    {
        public Input inputUp;
        public Input inputDown;
        public Input inputRight;
        public Input inputLeft;
        public Input inputExit;
    
        public Controller()
        {
            inputUp.SetInput(Keys.W, false);
            inputDown.SetInput(Keys.S, false);
            inputRight.SetInput(Keys.D, false);
            inputLeft.SetInput(Keys.A, false);
            inputExit.SetInput(Keys.Escape, false);
        }


        public void UpdateInputStates()
        {
            KeyboardState kstate = Keyboard.GetState();

            inputExit.newState(kstate.IsKeyDown(inputExit.getValue()));

            inputUp.newState(kstate.IsKeyDown(inputUp.getValue()));
            inputDown.newState(kstate.IsKeyDown(inputDown.getValue()));
            inputRight.newState(kstate.IsKeyDown(inputRight.getValue()));
            inputLeft.newState(kstate.IsKeyDown(inputLeft.getValue()));
        }
    }
}