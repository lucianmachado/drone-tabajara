using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Tests
{
    [TestClass()]
    public class DroneTests
    {
        [TestMethod]
        public void SetDirection_N()
        {
            Drone dr = new Logic.Drone();
            dr.SetDirection('N');
            Assert.AreEqual("(0, 1)", dr.GetCartesian());
        }
        [TestMethod]
        public void SetDirection_S()
        {
            Drone dr = new Logic.Drone();
            dr.SetDirection('S');
            Assert.AreEqual("(0, -1)", dr.GetCartesian());
        }
        [TestMethod]
        public void SetDirection_L()
        {
            Drone dr = new Logic.Drone();
            dr.SetDirection('L');
            Assert.AreEqual("(1, 0)", dr.GetCartesian());
        }
        [TestMethod]
        public void SetDirection_O()
        {
            Drone dr = new Logic.Drone();
            dr.SetDirection('O');
            Assert.AreEqual("(-1, 0)", dr.GetCartesian());
        }

        [TestMethod()]
        public void IsValidCharacterTest_false()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsValidCharacter('U'), false);
        }
        [TestMethod()]
        public void IsValidCharacterTest_true()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsValidCharacter('N'), true);
        }
        [TestMethod()]
        public void IsDigitTest_true()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsDigit('1'), true);
        }
        [TestMethod()]
        public void IsDigitTest_false()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsDigit('A'), false);
        }
        [TestMethod()]
        public void IsValidCoordTest_true()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsValidCoord('N'), true);
        }
        [TestMethod()]
        public void IsValidCoordTest_false_X()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.IsValidCoord('X'), false);
        }

        [TestMethod()]
        public void GetCartesianTest_00()
        {
            Drone drone = new Drone();
            Assert.AreEqual(drone.GetCartesian(), "(0, 0)");
        }
    }
}