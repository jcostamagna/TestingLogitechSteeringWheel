using System;
using SlimDX.DirectInput;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize DirectInput
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;
            var joystickGuid2 = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Driving,
                        DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid2 == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Other,
                        DeviceEnumerationFlags.AllDevices))
                {
                    //joystickGuid2 = deviceInstance.InstanceGuid;
                    //deviceInstance.GetType;
                    if (deviceInstance.ProductName == "HTC Vive")
                    {
                        Console.WriteLine("YES");
                        joystickGuid2 = deviceInstance.InstanceGuid;
                    }
                    Console.WriteLine(deviceInstance.ProductName);
                }

            // If Joystick not found, throws an error
            if (joystickGuid2 == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);
            //byte[] array = joystickGuid2.ToByteArray();

            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                Console.WriteLine("Effect available {0}", effectInfo.Name);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            byte[] array;

            // Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas) {
                    Console.WriteLine(state.X + " " + state.Y + " " + state.RotationZ );
                    //Console.WriteLine("TIRA DE BYTES: ");
                    array = joystickGuid2.ToByteArray();
                    String arrayString = "";
                    for (int i=0; i < array.Length; i++)
                    {
                        arrayString += array[i];
                        arrayString += " ";
                    }
                    //Console.WriteLine(arrayString);
                }
            }
        }
    }
}
